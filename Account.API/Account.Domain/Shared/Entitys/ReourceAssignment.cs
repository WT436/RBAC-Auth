using System;
using System.Collections.Generic;

namespace Account.Domain.Shared.Entitys
{
    public partial class ReourceAssignment
    {
        public int Id { get; set; }
        public int ResourceId { get; set; }
        public int PermissionId { get; set; }
        public bool? IsActived { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual RolePermission Permission { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
