using System;
using System.Collections.Generic;

namespace Brixton.Models
{
    public partial class CategoriesHe161048
    {
        public CategoriesHe161048()
        {
            ProductHe161048s = new HashSet<ProductHe161048>();
        }

        public int CaId { get; set; }
        public string CaName { get; set; } = null!;

        public virtual ICollection<ProductHe161048> ProductHe161048s { get; set; }
    }
}
