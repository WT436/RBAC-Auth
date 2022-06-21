﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class PermissionAssignment
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int PermissionId { get; set; }
        public bool? IsActive { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual Permission Permission { get; set; }
        public virtual Role Role { get; set; }
    }
}
