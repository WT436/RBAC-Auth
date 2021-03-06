using System;
using System.Collections.Generic;

namespace Account.Domain.Shared.Entitys
{
    public partial class HistoryTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdRecord { get; set; }
        public string DataNew { get; set; }
        public string DataOld { get; set; }
        public int ActionRecord { get; set; }
        public int CreateBy { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int UpdateBy { get; set; }
        public DateTime UpdatedOnUtc { get; set; }
    }
}
