using System;
using System.Collections.Generic;

namespace Account.Domain.Shared.Entitys
{
    public partial class SubjectGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public int SubjectId { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual Group Group { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
