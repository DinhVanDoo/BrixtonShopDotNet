using Brixton.Models;
using Brixton.Repository;

namespace Brixton.Interface
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly PRJ301_SE1705Context _context = new PRJ301_SE1705Context();
        public List<CategoryModel> getAllCat()
        {
            var getAllCat = _context.CategoriesHe161048s.Select(c => new CategoryModel
            {
                CaId = c.CaId,
                CaName = c.CaName
            });
            return getAllCat.ToList();
        }

        public CategoryModel? getCategory(int id)
        {
            var getCatById = _context.CategoriesHe161048s.SingleOrDefault(c => c.CaId == id);
            if (getCatById != null)
            {
                return new CategoryModel
                {
                    CaId = getCatById.CaId,
                    CaName = getCatById.CaName
                };
            }
            return null;
        }
    }
}
