using Brixton.Models;
using Microsoft.AspNetCore.Mvc;

namespace Brixton.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Home()
        {
            List<ProductHe161048> product;

            using (var context = new PRJ301_SE1705Context())
            {
                product = context.ProductHe161048s.OrderByDescending(p => p.ProId).Take(3).ToList();
            }
            return View(product);
        }
    }
}
