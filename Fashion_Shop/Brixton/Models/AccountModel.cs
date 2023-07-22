using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Brixton.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "Please enter your user name")]
        [MinLength(6, ErrorMessage = "Username must be at least 6 characters.")]
        [MaxLength(15, ErrorMessage = "Username must be less than 15 characters.")]
        [RegularExpression(@"^[a-zA-Z0-9]{6,15}$", ErrorMessage = "Username invalid")]
        public string AccId { get; set; } = null!;

        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters.")]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).+$", ErrorMessage = "Invalid password. Password must contain at least one letter and one number.")]
        public string AccPass { get; set; } = null!;
        public int Role { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Invalid Name")]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "Address is required.")]
        [RegularExpression(@"^[a-zA-Z0-9\s]+$", ErrorMessage = "Invalid Address")]
        public string UserAddress { get; set; } = null!;

        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression(@"^(0\d{9,10})$", ErrorMessage = "Invalid phone number")]
        public string UserPhone { get; set; } = null!;
        public int QuesId { get; set; }
        [Required(ErrorMessage = "Answer is required.")]
        public string Answer { get; set; } = null!;

        public AccountModel()
        {

        }

        public AccountModel(string accId, string accPass, int role, string userName, string userAddress, string userPhone, int quesId, string answer)
        {
            AccId = accId;
            AccPass = accPass;
            Role = role;
            UserName = userName;
            UserAddress = userAddress;
            UserPhone = userPhone;
            QuesId = quesId;
            Answer = answer;
        }
    }
}
