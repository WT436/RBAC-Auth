using Account.Domain.Shared.Entitys;
using System;
using System.Collections.Generic;

namespace Account.Domain.Shared.Entitys
{
    public partial class UserProfile
    {
        public UserProfile()
        {
            Address = new HashSet<Address>();
            DetailUser = new HashSet<DetailUser>();
            ProcessUser = new HashSet<ProcessUser>();
            Subject = new HashSet<Subject>();
            UserIp = new HashSet<UserIp>();
            UserPassword = new HashSet<UserPassword>();
            UserStatus = new HashSet<UserStatus>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string NumberPhone { get; set; }
        public int IsStatus { get; set; }
        public int LoginFallNumber { get; set; }
        public DateTime? LockAccountTime { get; set; }
        public bool IsAcceptTerm { get; set; }
        public string TimeZone { get; set; }
        public string FacebookId { get; set; }
        public string GoogleId { get; set; }
        public string ZaloId { get; set; }
        public bool IsDelete { get; set; }
        public bool? IsActive { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<DetailUser> DetailUser { get; set; }
        public virtual ICollection<ProcessUser> ProcessUser { get; set; }
        public virtual ICollection<Subject> Subject { get; set; }
        public virtual ICollection<UserIp> UserIp { get; set; }
        public virtual ICollection<UserPassword> UserPassword { get; set; }
        public virtual ICollection<UserStatus> UserStatus { get; set; }
    }
}
