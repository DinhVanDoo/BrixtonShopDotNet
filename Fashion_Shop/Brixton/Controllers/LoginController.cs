using Brixton.Interfaces;
using Brixton.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Brixton.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public LoginController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult Login()
        {
            if (TempData["UpdatePass"] != null)
            {
                ViewBag.message = TempData["UpdatePass"];
            }
            if (TempData["success"] != null)
            {
                ViewBag.message = TempData["success"];
            }
            return View(new AccountModel());
        }

        [HttpPost]
        public IActionResult Login(AccountModel accountModel)
        {
            var checkExitsAcc = _accountRepository.isExitsAccount(accountModel);
            if (checkExitsAcc != null)
            {
                string userJson = JsonConvert.SerializeObject(checkExitsAcc);
                HttpContext.Session.SetString("User", userJson);
                /*string userJson = JsonConvert.SerializeObject(checkExitsAcc);

                // Tạo một cookie để lưu trữ thông tin người dùng
                var cookieOptions = new CookieOptions
                {
                    // Đặt thời gian sống cho cookie (ví dụ: 30 phút)
                    Expires = DateTime.Now.AddMinutes(30),
                    // Đảm bảo rằng cookie chỉ truy cập được qua HTTP, không được JavaScript truy cập
                    HttpOnly = true
                };
                // Đặt giá trị của cookie
                Response.Cookies.Append("User", userJson, cookieOptions);*/


                if (checkExitsAcc.Role == 0) { return RedirectToAction("Dashboard", "Home", new { area = "Admin" }); }
                return RedirectToAction("Home", "Home");
            }
            else
            {
                ViewBag.Error = @"Username or password is incorrect";
            }

            return View(accountModel);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("User");
            return RedirectToAction("Login", "Login");
        }
    }
}
