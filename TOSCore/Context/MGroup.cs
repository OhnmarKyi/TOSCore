using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class MGroup
    {
        public string GroupId { get; set; } = null!;
        public string? GroupName { get; set; }
        public byte GroupInfoFlg { get; set; }
        public string? GroupIdinfo { get; set; }
        public string? InsertOperator { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
