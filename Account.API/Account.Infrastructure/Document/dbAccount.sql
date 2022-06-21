CREATE DATABASE [OAuthDB]	
GO
USE [OAuthDB]
GO
-- ====================================================================
---------------------------Miêu tả database----------------------------
-- ====================================================================
-- 0: FALSE, 1 : TRUE
GO
-- ====================================================================
-- Name      :  Ghi lại lịch sử của cả hệ thống
-- Meaning   :  
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [HistoryTable]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(50) NOT NULL,
	[Id_record] INT NOT NULL,
	[Data_new] VARCHAR(MAX) NOT NULL,
	[Data_old] VARCHAR(MAX) NOT NULL,
--  [action_record] => 0 : CREATE, 1:UPDATE, 2: DELETE, 3:, 4:, 5: 
	[Action_record] INT NOT NULL CHECK([action_record]>=0 AND [action_record]<=5),
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
--------------------Thông tin tài khoản--------------------------------
-- ====================================================================
GO
-- ====================================================================
-- Name      :  UserProfile
-- Meaning   :  Các hình thức đăng nhập của tài khoản
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [UserProfile]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[UserName] VARCHAR(100) UNIQUE NOT NULL, -- dùng lưu trữ tài khoản duy nhất
	[Email] VARCHAR(254) UNIQUE NULL, -- dùng lưu trữ email
	[NumberPhone] VARCHAR(15) NULL, -- số điện thoại
	[IsStatus] INT DEFAULT(0) NOT NULL CHECK([isStatus]>=0 AND [isStatus]<=10),
	-- 0 : tài khoản hoạt động                    -- 1 : tài khoản đang xác nhận đăng ký
	-- 2 : tài khoản đang được lấy lại            -- 3 : tài khoản đang để mất tài khoản
	-- 4 : tài khoản đang đăng nhập sai nhiều lần -- 5 : tài khoản đang checkpoint
	-- 6 : tài khoản đăng nhập nhanh			  -- 7 :
	-- 8 :										  -- 9 : 
	--10 :
	[LoginFallNumber] int NOT NULL DEFAULT(0) CHECK([loginFallNumber]>=0 AND [loginFallNumber]<=20), -- số lần đăng nhập thất bại liên tiếp
	[LockAccountTime] datetime NULL,-- thời gian khóa tài khoản
	[Is_accept_term] BIT NOT NULL DEFAULT(0), -- 0: FALSE, 1 : TRUE
	[Time_zone] VARCHAR(100) NULL,
	[FacebookId] VARCHAR(30) NULL,
	[GoogleId] VARCHAR(30)  NULL,
	[ZaloId] VARCHAR(30) NULL,
	[IsDelete] BIT DEFAULT(0) NOT NULL,
	[IsActive] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  UserAccountStatus
-- Meaning   :  Khôi phục mật khẩu + trạng thái tài khoản
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [UserStatus]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[AccountId] int NOT NULL FOREIGN KEY REFERENCES [UserProfile]([id]),
	[Code] VARCHAR(20) NULL,
	[StatusId] INT NOT NULL, -- xác định code lấy lại tài khoản
	[ReminderToken] VARCHAR(100) NULL, -- dùng để lưu trữ token khôi phục mật khẩu.
	[ReminderExpire] INT NOT NULL DEFAULT(300), -- thời điểm hết hiệu lực. tính bằng giây
	[UpdateCount] INT DEFAULT(0) NOT NULL,-- đếm số lần lỗi
	[IsActive] BIT DEFAULT(0) NOT NULL, -- trạng thái hoạt động
	[IsDelete] BIT DEFAULT(0) NOT NULL, -- còn cho phép sử dụng
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  UserLogin
-- Meaning   :  Lưu mật khẩu
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [UserPassword]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY, -- dùng lưu định dạng duy nhất tài khoản
	[AccountId] INT NOT NULL  FOREIGN KEY REFERENCES [UserProfile]([id]),
	[Password] VARCHAR(200) NOT NULL, -- dùng để lưu trữ password
	[PasswordSalt] VARCHAR(50) NOT NULL, --  dùng để lưu trữ chuỗi salt
	[PasswordHashAlgorithm] VARCHAR(50) NOT NULL, -- dùng để lưu thuật toán dùng để hash	
	[IsActived] BIT DEFAULT(0) NOT NULL, -- trạng thái hoạt động
	[IsDeleted] BIT DEFAULT(0) NOT NULL, -- còn cho phép sử dụng
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Theo dõi thiết bị đăng nhập của người dùng
-- Meaning   :  Cho phép đa, đơn thiết bị cùng kết nối trên một tài khoản
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [UserIp]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Ipv4] VARCHAR(500)  NULL,
	[Ipv6] VARCHAR(500)  NULL,
	[CountryCode] VARCHAR(20)  NULL,
	[CountryName] VARCHAR(200)  NULL,
	[City] VARCHAR(200)  NULL,
	[Postal] VARCHAR(20)  NULL,
	[Latitude] VARCHAR(20)  NULL,
	[Longitude] VARCHAR(20)  NULL,
	[State] VARCHAR(20)  NULL,
	[UserAgent] NVARCHAR(300) NULL,
	[AccountId] INT NOT NULL FOREIGN KEY REFERENCES [UserProfile]([id]),-- ip máy người dùng khi khởi tạo		
	[UpdateAcount] INT DEFAULT(0) NOT NULL,
	[IsActived] BIT DEFAULT(0) NOT NULL, -- trạng thái hoạt động
	[IsDeleted] BIT DEFAULT(0) NOT NULL, -- còn cho phép sử dụng
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Địa chỉ người dùng
-- Meaning   :  Lưu địa chỉ người dùng tối đa là 3 địa chỉ
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [Address]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[AdressLine] NVARCHAR(500) NOT NULL,-- địa chỉ chính
	[Description] NVARCHAR(200) NOT NULL, -- miêu tả
	[IsActived] BIT DEFAULT(1) NOT NULL, -- trạng thái kích hoạt
	[IsDeleted] BIT DEFAULT(0) NOT NULL, -- trạng thái -- 0: FALSE, 1 : TRUE
	[AccountId] int FOREIGN KEY REFERENCES [UserProfile]([id]),
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Thông tin của người dùng
-- Meaning   :  Lưu thông tin cá nhân của người dùng khi được cho phép
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [DetailUser]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[FirsName] NVARCHAR(255) NULL,
	[LastName] NVARCHAR(255) NULL,
	[Picture] VARCHAR(200) NULL, -- ảnh
	[Gender] INT NOT NULL CHECK([gender] >= 0 AND [gender] <= 3),-- giới tính
	[Description] NVARCHAR(200) NOT NULL, -- miêu tả
	[IsActived] BIT DEFAULT(1) NOT NULL, -- trạng thái
	[AccountId] INT FOREIGN KEY REFERENCES [UserProfile]([id]),
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Theo dõi đăng nhập
-- Meaning   :  
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [ProcessUser]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Description] NVARCHAR(MAX) NOT NULL, -- mô tả
	[ReminderToken] NVARCHAR(MAX) NULL,
	[IpUser] VARCHAR(20) NOT NULL, -- ip người dùng
	[IsStatus] BIT DEFAULT(0) NOT NULL, -- trạng thái 
	[Device] NVARCHAR(100) NOT NULL, -- thiết bị
	[AccountId] INT FOREIGN KEY REFERENCES [UserProfile]([id]),
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
---------------------------Phân quyền----------------------------------
-- ====================================================================
GO
-- ====================================================================
-- Name      :  Thông tin liên quan đến group phân quyền
-- Meaning   :  Nhóm người dùng
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [Group]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[NameGroup] NVARCHAR(300) NOT NULL, -- tên nhóm
	[Status] INT NOT NULL DEFAULT(0) CHECK([status] >= 0 AND [status] <= 5), -- trạng thái nhóm
	[Description] NVARCHAR(MAX) NULL, -- Mô tả
	[Introduce] NVARCHAR(MAX) NULL, -- phần giới thiệu
	[GroupType] VARCHAR(300) NULL,-- Loại nhóm
	[LinkedPages]	VARCHAR(300) NULL,-- Trang được liên kết với nhóm
	[MembershipApproval] VARCHAR(300) NULL,-- Duyệt thành viên
	[PostApproval] VARCHAR(300) NULL,-- Phê duyệt bài đăng
	[Tags] VARCHAR(300) NULL,--Tags
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Chủ thể kết nối
-- Meaning   :  Cổng kết nối chung của tài khoản và nhóm với phân quyền
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [Subject]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[UserId] INT NOT NULL FOREIGN KEY REFERENCES [UserProfile]([id]),-- id người dùng
	[GroupId] INT NULL FOREIGN KEY REFERENCES [Group]([id]) ,-- tên nhóm mà người dùng này đang tham gia
	[IsActived] BIT DEFAULT(1) NOT NULL, -- Trạng thái của người dùng trong bộ quyền này
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Chủ thể của nhóm
-- Meaning   :  Kết nối [Group] và [Subject]
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [SubjectGroup]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] NVARCHAR(300) NOT NULL, -- Tên
	[GroupId] INT FOREIGN KEY REFERENCES [Group]([id]) NOT NULL,
	[SubjectId] INT FOREIGN KEY REFERENCES [Subject]([id]) NOT NULL,
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Hành động cụ thể
-- Meaning   :  Các hành động như GET,WATCH,UPDATE,.... của Table , access ... của các hàm, access của các URL
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [Atomic]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(300) NOT NULL, -- tên phần tử của quyền
	[Description] NVARCHAR(MAX) NOT NULL,
	[TypesRsc] INT NOT NULL, -- kiểu định dạng cho hành động 0:URL,1:Namespace,2:FUNCTION.....
	[IsActived] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Vai trò
-- Meaning   :  Quản lý các vai trò chính của nhóm và người dùng cá nhân, ví dụ như giám đốc là một vao trò và giám đốc các các quyền khác nhau
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [RolePermission]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL, -- tên vai trò
	[Description] NVARCHAR(MAX) NOT NULL, -- mô tả
	[Level] INT CHECK([Level]>= 0) NOT NULL, -- cấp độ vai trò
	[Types] INT CHECK([Types]>= 0 AND [Types]<= 2) NOT NULL, -- 0 : role, 1 : permission, 2 : RolePermission
	[ManageId] INT FOREIGN KEY REFERENCES [RolePermission]([id])  NOT NULL, -- vai trò quản lý or permission
	[AtomicId] INT FOREIGN KEY REFERENCES [Atomic]([id]) NULL, -- Hành động của nhóm quyền
	[TypesRsc] INT NULL, -- kiểu định dạng cho hành động 0:URL,1:Namespace,2:FUNCTION.....
	[RoleId] INT FOREIGN KEY REFERENCES [RolePermission]([id]) NULL,
	[PermissionId] INT FOREIGN KEY REFERENCES [RolePermission]([id]) NULL,
	[IsActived] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[IsDeleted] BIT DEFAULT(0) NOT NULL,
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
-- ====================================================================
-- Name      :  Phân công cho vai trò
-- Meaning   :  Chi tiết của từng vai trò đó là nhiều quyền
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [SubjectAssignment]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[RolePermissionId] INT FOREIGN KEY REFERENCES [RolePermission]([id]) NOT NULL ,
	[SubjectId] INT FOREIGN KEY REFERENCES [Subject]([id]) NOT NULL ,
	[IsActived] BIT DEFAULT(1) NOT NULL, -- trạng thái vai trò
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)

GO
-- ====================================================================
-- Name      :  Nguồn gốc, tài nguyên
-- Meaning   :  Namespace, url, function, ...... cụ thể
-- Create by :  WT436
-- Create at :  Monday, May 12, 2021
-- Update at :  Wednesday, November 24, 2021
-- ====================================================================
CREATE TABLE [Resource]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY ,
	[Name] NVARCHAR(300) UNIQUE NOT NULL, -- lưu trữ các bảng
	[TypesRsc] INT NOT NULL, -- kiểu định dạng cho hành động 0:URL,1:Namespace,2:FUNCTION.....
	[Description] NVARCHAR(MAX) NOT NULL,
	[IsActived] BIT DEFAULT(1) NOT NULL, -- trạng thái
	[CreateBy] INT NOT NULL DEFAULT(0), -- người tạo
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)
GO
CREATE TABLE [ReourceAssignment]
(
	[Id] INT IDENTITY(1,1) PRIMARY KEY,
	[ResourceId] INT FOREIGN KEY REFERENCES [Resource]([id]) NOT NULL ,
	[PermissionId] INT FOREIGN KEY REFERENCES [RolePermission]([id]) NOT NULL ,
	[IsActived] BIT DEFAULT(1) NOT NULL, 
	[CreateBy] INT NOT NULL DEFAULT(0), 
	[CreatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), --ngày tạo
	[UpdateBy] INT NOT NULL DEFAULT(0), -- người Sửa
	[UpdatedOnUtc] DATETIME2(7) NOT NULL DEFAULT(GETDATE()), -- ngày update
)

