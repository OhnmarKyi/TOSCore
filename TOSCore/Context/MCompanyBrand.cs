using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class MCompanyBrand
    {
        public string? CompanyCd { get; set; }
        public int? BrandCd { get; set; }
        public string? InsertOperator { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
