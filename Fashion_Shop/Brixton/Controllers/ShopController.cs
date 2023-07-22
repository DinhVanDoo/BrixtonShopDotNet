using Brixton.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;
using X.PagedList.Mvc;
namespace Brixton.Controllers;

using Brixton.Repository;
using X.PagedList;

public class ShopController : Controller
{

    private readonly IProductRepository _productRepository;
    private readonly ICategoryRepository _categoryRepository;

    public ShopController(IProductRepository productRepository, ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
    }
    public IActionResult ShopAll(int? caid, string? key, int? page)
    {
        IPagedList<ProductModel> products;
        ViewBag.listCa = _categoryRepository.getAllCat();
        int pageSize = 6;
        int pageNumber;
        if (page == null)
        {
            pageNumber = 1;
        }
        else if (page < 1)
        {
            pageNumber = 1;
        }
        else
        {
            pageNumber = (int)page;
        }
        if (key == null)
        {
            key = "";
        }
        ViewBag.key = key;
        ViewBag.caid = caid;
        products = _productRepository.getAllProductByCaId(caid, key).ToPagedList(pageNumber, pageSize);

        return View(products);
    }





    public IActionResult Detail(int id)
    {
        ProductHe161048 product;

        using (var context = new PRJ301_SE1705Context())
        {

            product = context.ProductHe161048s.First(x => x.ProId == id);
            CategoriesHe161048 categories = context.CategoriesHe161048s.First(c => c.CaId == product.CaId);
            product.Ca = categories;

        }
        return View(product);
    }
}

