using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class MPrice
    {
        public int MakerItemAdminCd { get; set; }
        public byte RankingFlg { get; set; }
        public decimal? SalePrice { get; set; }
        public int ImageName { get; set; }
        public string? InsertOperator { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
