using Brixton.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Brixton.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            AccountModel? model = new AccountModel();
            string? userJson = HttpContext.Session.GetString("UserToCheckQuesion");
            if (userJson != null)
            {
                model = JsonConvert.DeserializeObject<AccountModel>(userJson);
            }
            return View(model);
        }
    }
}
