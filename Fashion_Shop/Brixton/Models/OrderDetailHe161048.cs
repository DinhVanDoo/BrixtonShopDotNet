using System;
using System.Collections.Generic;

namespace Brixton.Models
{
    public partial class OrderDetailHe161048
    {
        public int OrId { get; set; }
        public int ProId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public virtual OrderHe161048 Or { get; set; } = null!;
        public virtual ProductHe161048 Pro { get; set; } = null!;
    }
}
