using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class LLog
    {
        public int Seq { get; set; }
        public DateTime OperateDate { get; set; }
        public TimeSpan OperateTime { get; set; }
        public string? CompanyCd { get; set; }
        public string? ProcessedProgram { get; set; }
        public string? AccessPc { get; set; }
        public string? OperateMode { get; set; }
        public string? KeyItem { get; set; }
    }
}
