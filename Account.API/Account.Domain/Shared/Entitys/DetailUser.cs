using System;
using System.Collections.Generic;

namespace Account.Domain.Shared.Entitys
{
    public partial class DetailUser
    {
        public int Id { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Picture { get; set; }
        public int Gender { get; set; }
        public string Description { get; set; }
        public bool? IsActived { get; set; }
        public int? AccountId { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual UserProfile Account { get; set; }
    }
}
