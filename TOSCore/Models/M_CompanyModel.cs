namespace TOSCore.Models
{
    public class M_CompanyModel
    {
        public string Mode { get; set; } = null!;
        public string CompanyCD { get; set; } = null!;
        public string? CompanyName { get; set; }
        public string? Password { get; set; }
        public byte UserRole { get; set; }
        public string? ShortName { get; set; }
        public string ZipCode { get; set; } = null!;
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
        public List<M_CompanyShippingModel> ShippingModel { get; set; }
        public List<M_CompanyTagModel> TagModel { get; set; }
    }
}
