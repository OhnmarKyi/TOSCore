using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class TOrderHeader
    {
        public string OrderId { get; set; } = null!;
        public int? ShippingId { get; set; }
        public string? ShippingName { get; set; }
        public string? ZipCd1 { get; set; }
        public string? ZipCd2 { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? TelephoneNo { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? ConsumptionTax { get; set; }
        public string? Memo { get; set; }
        public string? CustomerCd { get; set; }
        public DateTime? OrderDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
