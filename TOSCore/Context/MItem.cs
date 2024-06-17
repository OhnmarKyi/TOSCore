using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class MItem
    {
        public int MakerItemAdminCd { get; set; }
        public string? MakerItemCd { get; set; }
        public string? ItemName { get; set; }
        public string? BrandCd { get; set; }
        public decimal ListPriceWithoutTax { get; set; }
        public decimal ListPriceInTax { get; set; }
        public decimal SalePriceWithoutTax { get; set; }
        public decimal SalePriceInTax { get; set; }
        public string? GeneralClassName { get; set; }
        public string? NormalClassName { get; set; }
        public string? AdvenceClassName { get; set; }
        public int? Lot { get; set; }
        public string? ImageName { get; set; }
        public int? Year { get; set; }
        public string? Season { get; set; }
        public string? CatelogNo { get; set; }
        public string? InsertOperator { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
