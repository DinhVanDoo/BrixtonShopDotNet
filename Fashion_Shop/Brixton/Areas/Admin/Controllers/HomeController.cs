using Brixton.Models;
using Brixton.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using X.PagedList;

namespace Brixton.Areas.Admin.Controllers
{

    [Area("admin")]
    [Route("admin")]
    public class HomeController : Controller
    {

        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public HomeController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        [Route("Dashboard")]
        public IActionResult Dashboard(int? page)
        {
            IPagedList<ProductModel> products;
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

            products = _productRepository.getAllProduct().ToPagedList(pageNumber, pageSize);


            return View(products);
        }
        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            if (TempData["CreateSuccess"] != null)
            {
                ViewBag.MessSuccess = TempData["CreateSuccess"].ToString();
            }
            return View(new ProductModel());
        }
        [HttpPost]
        [Route("Create")]
        [ValidateAntiForgeryToken]

        public IActionResult Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                _productRepository.AddProduct(model);
                TempData["CreateSuccess"] = "Create Successfully!";
                return RedirectToAction("Create");
            }
            return View(model);
        }

        [HttpGet]
        [Route("Edit")]
        public IActionResult Edit(int Pid)
        {
            var productById = _productRepository.getProductById(Pid);
            if (productById == null)
            {
                return NotFound();
            }
            if (TempData["SuccessMessage"] != null)
            {
                ViewBag.EditSuccess = TempData["SuccessMessage"].ToString();
            }
            return View(productById);
        }


        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(ProductModel model, int Pid)
        {
            if (ModelState.IsValid)
            {
                _productRepository.UpdateProduct(model, Pid);
                TempData["SuccessMessage"] = "Edit Successfully!";
                return RedirectToAction("Edit", new { Pid = Pid });
            }

            return View(model);
        }


        [Route("Delete")]
        public IActionResult Delete(int Pid)
        {
            _productRepository.DeleteProduct(Pid);
            return RedirectToAction("Dashboard");
        }
    }
}
