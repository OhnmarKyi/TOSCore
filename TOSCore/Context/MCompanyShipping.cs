using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class MCompanyShipping
    {
        public string? CompanyCd { get; set; }
        public int ShippingId { get; set; }
        public string? ShippingName { get; set; }
        public string? ZipCd1 { get; set; }
        public string? ZipCd2 { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? TelephoneNo { get; set; }
        public string? FaxNo { get; set; }
        public string? InsertOperator { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
