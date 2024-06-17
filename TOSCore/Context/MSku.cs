using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class MSku
    {
        public int AdminCd { get; set; }
        public int MakerItemAdminCd { get; set; }
        public string? Skucd { get; set; }
        public string? Jancd { get; set; }
        public string? SizeName { get; set; }
        public string? ColorName { get; set; }
        public int ZaikoSu { get; set; }
        public string? InsertOperator { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
