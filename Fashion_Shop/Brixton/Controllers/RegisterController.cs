using Brixton.Interfaces;
using Brixton.Models;
using Microsoft.AspNetCore.Mvc;

namespace Brixton.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public RegisterController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult Register()
        {
            if (TempData["errorExist"] != null)
            {
                ViewBag.exit = TempData["errorExist"];
            }
            return View(new AccountModel());
        }

        [HttpPost]
        public IActionResult Register(AccountModel model)
        {
            if (ModelState.IsValid)
            {
                var checkExit = _accountRepository.isExits(model.AccId);
                if (checkExit)
                {
                    TempData["errorExist"] = "User Name Is Exist";
                    ViewBag.exit = TempData["errorExist"];
                    return View(model);
                }
                else
                {
                    _accountRepository.AddAccount(model);
                    TempData["success"] = "Your account has just been created successfully";
                    return RedirectToAction("Login", "Login");
                }
            }
            else
            {
                return View(model);
            }
        }

    }
}
