using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class MGroupList
    {
        public string CompanyCd { get; set; } = null!;
        public string GroupId { get; set; } = null!;
        public string? InsertOperator { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
