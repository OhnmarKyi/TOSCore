using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class MCompany
    {
        public string CompanyCd { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? Password { get; set; }
        public byte UserRole { get; set; }
        public string? ShortName { get; set; }
        public string? ZipCd1 { get; set; }
        public string? ZipCd2 { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? TelephoneNo { get; set; }
        public string? FaxNo { get; set; }
        public string? PresidentName { get; set; }
        public byte RankingFlg { get; set; }
        public string? InsertOperator { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
