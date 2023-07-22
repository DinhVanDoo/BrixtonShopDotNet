using System;
using System.Collections.Generic;

namespace Brixton.Models
{
    public partial class AccountHe161048
    {
        public AccountHe161048()
        {
            OrderHe161048s = new HashSet<OrderHe161048>();
        }

        public string AccId { get; set; } = null!;
        public string AccPass { get; set; } = null!;
        public int Role { get; set; }
        public string UserName { get; set; } = null!;
        public string UserAddress { get; set; } = null!;
        public string UserPhone { get; set; } = null!;
        public int QuesId { get; set; }
        public string Answer { get; set; } = null!;

        public virtual SecurityQuestionHe161048 Ques { get; set; } = null!;
        public virtual ICollection<OrderHe161048> OrderHe161048s { get; set; }
    }
}
