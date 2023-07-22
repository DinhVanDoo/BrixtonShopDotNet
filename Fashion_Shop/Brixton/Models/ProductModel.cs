using System.ComponentModel.DataAnnotations;

namespace Brixton.Models
{
    public class ProductModel
    {
        public int ProId { get; set; }


        [Required(ErrorMessage = "Product Name is required")]
        [MinLength(8, ErrorMessage = "Name must have at least 8 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Tên sản phẩm phải là chữ")]
        public string ProName { get; set; } = null!;


        [Required(ErrorMessage = "Image path is required")]
        public string ProImg { get; set; } = null!;


        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value")]
        public double ProPrice { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(20, ErrorMessage = "Description must have at least 20 characters")]
        public string ProDetail { get; set; } = null!;


        [Required(ErrorMessage = "Category ID is required")]
        public int CaId { get; set; }


        [Required(ErrorMessage = "Collectsion ID is required")]
        public int CoId { get; set; }


    }
}
