using System;
using System.Collections.Generic;

namespace Brixton.Models
{
    public partial class ProductHe161048
    {
        public int ProId { get; set; }
        public string ProName { get; set; } = null!;
        public string ProImg { get; set; } = null!;
        public double ProPrice { get; set; }
        public string ProDetail { get; set; } = null!;
        public int CaId { get; set; }
        public int CoId { get; set; }

        public virtual CategoriesHe161048 Ca { get; set; } = null!;
        public virtual CollectionsHe161048 Co { get; set; } = null!;
    }
}
