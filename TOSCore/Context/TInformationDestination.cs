using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class TInformationDestination
    {
        public int InformationId { get; set; }
        public string? DestinationId { get; set; }
        public string? InsertOperator { get; set; }
        public DateTime? InsertDateTime { get; set; }
        public string? UpdateOperator { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
