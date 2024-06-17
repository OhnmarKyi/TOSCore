using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class MJobTimeable
    {
        public string CompanyCd { get; set; } = null!;
        public string? OrderAblePeriod { get; set; }
        public string? CancelAblePeriod { get; set; }
        public string? ExceptionAboutPeriod { get; set; }
        public string? InsertOperator { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
