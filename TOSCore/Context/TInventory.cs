using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class TInventory
    {
        public int AdminCd { get; set; }
        public int ZaikoSu { get; set; }
        public int PlanInstockCount { get; set; }
        public int PlanInstockDate { get; set; }
        public string? InsertOperator { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
