using Brixton.Models;

namespace Brixton.Repository
{
    public interface ICategoryRepository
    {
        List<CategoryModel> getAllCat();

        CategoryModel? getCategory(int id);
    }
}
