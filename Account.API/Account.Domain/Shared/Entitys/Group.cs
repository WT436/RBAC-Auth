using System;
using System.Collections.Generic;

namespace Account.Domain.Shared.Entitys
{
    public partial class Group
    {
        public Group()
        {
            Subject = new HashSet<Subject>();
            SubjectGroup = new HashSet<SubjectGroup>();
        }

        public int Id { get; set; }
        public string NameGroup { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string Introduce { get; set; }
        public string GroupType { get; set; }
        public string LinkedPages { get; set; }
        public string MembershipApproval { get; set; }
        public string PostApproval { get; set; }
        public string Tags { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }

        public virtual ICollection<Subject> Subject { get; set; }
        public virtual ICollection<SubjectGroup> SubjectGroup { get; set; }
    }
}
