using System;
using System.Collections.Generic;

namespace Account.Domain.Shared.Entitys
{
    public partial class SubjectAssignment
    {
        public int Id { get; set; }
        public int RolePermissionId { get; set; }
        public int SubjectId { get; set; }
        public bool? IsActived { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual RolePermission RolePermission { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
