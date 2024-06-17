using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class TOrderDetail
    {
        public string OrderId { get; set; } = null!;
        public int AdminCd { get; set; }
        public int OrderItem { get; set; }
        public int StockItem { get; set; }
        public int PlanStock { get; set; }
        public decimal SalePrice { get; set; }
        public decimal TotalAmount { get; set; }
        public byte OrderStatus { get; set; }
        public byte? DeliveryFlg { get; set; }
        public decimal? Shippingfee { get; set; }
        public string? DeliveryCompanyCd { get; set; }
        public string? Memo { get; set; }
        public DateTime AvailableShippingDate { get; set; }
        public DateTime? ShippingDate { get; set; }
        public string? CustomerCd { get; set; }
        public DateTime? OrderDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
