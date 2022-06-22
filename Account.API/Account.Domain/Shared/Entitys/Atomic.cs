﻿using System;
using System.Collections.Generic;

namespace Account.Domain.Shared.Entitys
{
    public partial class Atomic
    {
        public Atomic()
        {
            RolePermission = new HashSet<RolePermission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int TypesRsc { get; set; }
        public bool? IsActived { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<RolePermission> RolePermission { get; set; }
    }
}
