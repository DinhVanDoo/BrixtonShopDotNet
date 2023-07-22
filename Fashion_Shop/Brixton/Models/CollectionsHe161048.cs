using System;
using System.Collections.Generic;

namespace Brixton.Models
{
    public partial class CollectionsHe161048
    {
        public CollectionsHe161048()
        {
            ProductHe161048s = new HashSet<ProductHe161048>();
        }

        public int CoId { get; set; }
        public string CoName { get; set; } = null!;

        public virtual ICollection<ProductHe161048> ProductHe161048s { get; set; }
    }
}
