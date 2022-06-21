﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Account.Domain.Shared.Entitys
{
    public partial class SubjectGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GorupId { get; set; }
        public int SubjectId { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual Group Gorup { get; set; }
        public virtual Subject Subject { get; set; }
    }
}