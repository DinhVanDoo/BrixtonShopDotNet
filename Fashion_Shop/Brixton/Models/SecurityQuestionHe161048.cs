using System;
using System.Collections.Generic;

namespace Brixton.Models
{
    public partial class SecurityQuestionHe161048
    {
        public SecurityQuestionHe161048()
        {
            AccountHe161048s = new HashSet<AccountHe161048>();
        }

        public int QuesId { get; set; }
        public string Question { get; set; } = null!;

        public virtual ICollection<AccountHe161048> AccountHe161048s { get; set; }
    }
}
