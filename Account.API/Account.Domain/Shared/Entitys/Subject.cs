using System;
using System.Collections.Generic;

namespace Account.Domain.Shared.Entitys
{
    public partial class Subject
    {
        public Subject()
        {
            SubjectAssignment = new HashSet<SubjectAssignment>();
            SubjectGroup = new HashSet<SubjectGroup>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int? GroupId { get; set; }
        public bool? IsActived { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual Group Group { get; set; }
        public virtual UserProfile User { get; set; }
        public virtual ICollection<SubjectAssignment> SubjectAssignment { get; set; }
        public virtual ICollection<SubjectGroup> SubjectGroup { get; set; }
    }
}
