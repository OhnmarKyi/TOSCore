using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class MBrand
    {
        public string BrandCd { get; set; } = null!;
        public string? BrandName { get; set; }
        public string? InsertOperator { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
