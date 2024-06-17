using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class TInformation
    {
        public int InformationId { get; set; }
        public string? TitleName { get; set; }
        public byte DestinationFlg { get; set; }
        public byte EffectFlg { get; set; }
        public byte InformationType { get; set; }
        public DateTime DisplayStartDate { get; set; }
        public DateTime DisplayEndDate { get; set; }
        public DateTime Date { get; set; }
        public string? AttachedFile1 { get; set; }
        public string? AttachedFile2 { get; set; }
        public string? AttachedFile3 { get; set; }
        public string? AttachedFile4 { get; set; }
        public string? DetailInformation { get; set; }
        public string? InsertOperator { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
