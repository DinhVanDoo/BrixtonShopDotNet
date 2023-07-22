using Brixton.Models;

namespace Brixton.Repository
{
    public interface IProductRepository
    {
        List<ProductModel> getAllProduct();

        ProductModel getProductById(int id);

        ProductModel AddProduct(ProductModel product);

        void DeleteProduct(int id);

        void UpdateProduct(ProductModel product, int Pid);

        List<ProductModel> getAllProductByCaId(int? caId, string? key);


    }
}
