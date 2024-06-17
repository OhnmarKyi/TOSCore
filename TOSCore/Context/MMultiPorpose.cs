using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class MMultiPorpose
    {
        public string? Id { get; set; }
        public string Key { get; set; } = null!;
        public string? Idname { get; set; }
        public string? Text1 { get; set; }
        public string? Text2 { get; set; }
        public string? Text3 { get; set; }
        public string? Text4 { get; set; }
        public string? Text5 { get; set; }
        public decimal? Num1 { get; set; }
        public int? Num2 { get; set; }
        public int? Num3 { get; set; }
        public int? Num4 { get; set; }
        public int? Num5 { get; set; }
        public DateTime? Datetime1 { get; set; }
        public DateTime? Datetime2 { get; set; }
        public DateTime? Datetime3 { get; set; }
        public string? Creator { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public string? Updater { get; set; }
        public DateTime? UpdatedDateTime { get; set; }
    }
}
