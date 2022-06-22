using System;
using Account.Domain.Shared.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Account.Infrastructure.DBContext
{
    public partial class OAuthDBContext : DbContext
    {
        public OAuthDBContext()
        {
        }

        public OAuthDBContext(DbContextOptions<OAuthDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Atomic> Atomic { get; set; }
        public virtual DbSet<DetailUser> DetailUser { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<HistoryTable> HistoryTable { get; set; }
        public virtual DbSet<ProcessUser> ProcessUser { get; set; }
        public virtual DbSet<ReourceAssignment> ReourceAssignment { get; set; }
        public virtual DbSet<Resource> Resource { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<SubjectAssignment> SubjectAssignment { get; set; }
        public virtual DbSet<SubjectGroup> SubjectGroup { get; set; }
        public virtual DbSet<UserIp> UserIp { get; set; }
        public virtual DbSet<UserPassword> UserPassword { get; set; }
        public virtual DbSet<UserProfile> UserProfile { get; set; }
        public virtual DbSet<UserStatus> UserStatus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=OAuthDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AdressLine)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Address__Account__5812160E");
            });

            modelBuilder.Entity<Atomic>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<DetailUser>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.FirsName).HasMaxLength(255);

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastName).HasMaxLength(255);

                entity.Property(e => e.Picture)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.DetailUser)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__DetailUse__Accou__60A75C0F");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.GroupType)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.LinkedPages)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.MembershipApproval)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.NameGroup)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.PostApproval)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Tags)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<HistoryTable>(entity =>
            {
                entity.Property(e => e.ActionRecord).HasColumnName("Action_record");

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DataNew)
                    .IsRequired()
                    .HasColumnName("Data_new")
                    .IsUnicode(false);

                entity.Property(e => e.DataOld)
                    .IsRequired()
                    .HasColumnName("Data_old")
                    .IsUnicode(false);

                entity.Property(e => e.IdRecord).HasColumnName("Id_record");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<ProcessUser>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Device)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IpUser)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.ProcessUser)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__ProcessUs__Accou__68487DD7");
            });

            modelBuilder.Entity<ReourceAssignment>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.ReourceAssignment)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReourceAs__Permi__2BFE89A6");

                entity.HasOne(d => d.Resource)
                    .WithMany(p => p.ReourceAssignment)
                    .HasForeignKey(d => d.ResourceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ReourceAs__Resou__2B0A656D");
            });

            modelBuilder.Entity<Resource>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Resource__737584F6361DDBA3")
                    .IsUnique();

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<RolePermission>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Atomic)
                    .WithMany(p => p.RolePermission)
                    .HasForeignKey(d => d.AtomicId)
                    .HasConstraintName("FK__RolePermi__Atomi__10566F31");

                entity.HasOne(d => d.Manage)
                    .WithMany(p => p.InverseManage)
                    .HasForeignKey(d => d.ManageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RolePermi__Manag__0F624AF8");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.InversePermission)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK__RolePermi__Permi__123EB7A3");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.InverseRole)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__RolePermi__RoleI__114A936A");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK__Subject__GroupId__778AC167");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Subject)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Subject__UserId__76969D2E");
            });

            modelBuilder.Entity<SubjectAssignment>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActived)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.RolePermission)
                    .WithMany(p => p.SubjectAssignment)
                    .HasForeignKey(d => d.RolePermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectAs__RoleP__1AD3FDA4");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectAssignment)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectAs__Subje__1BC821DD");
            });

            modelBuilder.Entity<SubjectGroup>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.SubjectGroup)
                    .HasForeignKey(d => d.GroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectGr__Group__7F2BE32F");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.SubjectGroup)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SubjectGr__Subje__00200768");
            });

            modelBuilder.Entity<UserIp>(entity =>
            {
                entity.Property(e => e.City)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CountryCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CountryName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Ipv4)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Ipv6)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Longitude)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Postal)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserAgent).HasMaxLength(300);

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.UserIp)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserIp__AccountI__4CA06362");
            });

            modelBuilder.Entity<UserPassword>(entity =>
            {
                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHashAlgorithm)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.UserPassword)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserPassw__Accou__440B1D61");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__UserProf__A9D10534735CF095")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UQ__UserProf__C9F2845621E0A10A")
                    .IsUnique();

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(254)
                    .IsUnicode(false);

                entity.Property(e => e.FacebookId)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.GoogleId)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.IsAcceptTerm).HasColumnName("Is_accept_term");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LockAccountTime).HasColumnType("datetime");

                entity.Property(e => e.NumberPhone)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.TimeZone)
                    .HasColumnName("Time_zone")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ZaloId)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserStatus>(entity =>
            {
                entity.Property(e => e.Code)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ReminderExpire).HasDefaultValueSql("((300))");

                entity.Property(e => e.ReminderToken)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOnUtc).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.UserStatus)
                    .HasForeignKey(d => d.AccountId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserStatu__Accou__398D8EEE");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
