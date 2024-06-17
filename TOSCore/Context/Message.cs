using System;
using System.Collections.Generic;

namespace TOSCore.Context
{
    public partial class Message
    {
        public string? Id { get; set; }
        public string Key { get; set; } = null!;
        public string? Message1 { get; set; }
        public string? Message2 { get; set; }
        public string? Message3 { get; set; }
        public string? Message4 { get; set; }
        public string? Message5 { get; set; }
        public string? Remark { get; set; }
        public string? Creater { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Updater { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
