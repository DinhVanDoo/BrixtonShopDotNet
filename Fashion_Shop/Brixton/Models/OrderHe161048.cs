using System;
using System.Collections.Generic;

namespace Brixton.Models
{
    public partial class OrderHe161048
    {
        public int OrId { get; set; }
        public DateTime OrDate { get; set; }
        public string AccId { get; set; } = null!;
        public double TotalMoney { get; set; }

        public virtual AccountHe161048 Acc { get; set; } = null!;
    }
}
