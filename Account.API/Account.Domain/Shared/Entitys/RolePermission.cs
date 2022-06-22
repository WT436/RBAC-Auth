using System;
using System.Collections.Generic;

namespace Account.Domain.Shared.Entitys
{
    public partial class RolePermission
    {
        public RolePermission()
        {
            InverseManage = new HashSet<RolePermission>();
            InversePermission = new HashSet<RolePermission>();
            InverseRole = new HashSet<RolePermission>();
            ReourceAssignment = new HashSet<ReourceAssignment>();
            SubjectAssignment = new HashSet<SubjectAssignment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Level { get; set; }
        public int Types { get; set; }
        public int ManageId { get; set; }
        public int? AtomicId { get; set; }
        public int? TypesRsc { get; set; }
        public int? RoleId { get; set; }
        public int? PermissionId { get; set; }
        public bool? IsActived { get; set; }
        public bool IsDeleted { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual Atomic Atomic { get; set; }
        public virtual RolePermission Manage { get; set; }
        public virtual RolePermission Permission { get; set; }
        public virtual RolePermission Role { get; set; }
        public virtual ICollection<RolePermission> InverseManage { get; set; }
        public virtual ICollection<RolePermission> InversePermission { get; set; }
        public virtual ICollection<RolePermission> InverseRole { get; set; }
        public virtual ICollection<ReourceAssignment> ReourceAssignment { get; set; }
        public virtual ICollection<SubjectAssignment> SubjectAssignment { get; set; }
    }
}
