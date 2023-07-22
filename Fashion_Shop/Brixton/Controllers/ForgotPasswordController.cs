using Brixton.Interfaces;
using Brixton.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Principal;
using System.Text.RegularExpressions;

namespace Brixton.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public ForgotPasswordController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult ForgotPassword()
        {
            if (TempData["ErrorCookie"] != null)
            {
                ViewBag.NoneCookie = TempData["ErrorCookie"];
            }
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string username)
        {

            if (_accountRepository.isExits(username))
            {
                var acc = _accountRepository.getAccountByAccID(username);
                string userJson = JsonConvert.SerializeObject(acc);

                var cookieOptions = new CookieOptions
                {

                    Expires = DateTime.Now.AddSeconds(300),
                    HttpOnly = true
                };

                Response.Cookies.Append("UserToCheckQuesion", userJson, cookieOptions);
                Response.Cookies.Append("check", "false", cookieOptions);
                //HttpContext.Session.SetString("UserToCheckQuesion", userJson);
                return RedirectToAction("CheckQuestion");
            }
            else
            {
                ViewBag.Error = "Not found account";
                return View();
            }
        }



        public IActionResult CheckQuestion()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckQuestion(int quesId, string answer)
        {
            //string? userJson = HttpContext.Session.GetString("UserToCheckQuesion");
            string? userJson = HttpContext.Request.Cookies["UserToCheckQuesion"];
            if (!string.IsNullOrEmpty(userJson))
            {
                var acc = JsonConvert.DeserializeObject<AccountModel>(userJson);
                if (acc != null)
                {
                    if (acc.QuesId == quesId && acc.Answer.Equals(answer))
                    {
                        var cookieOptions = new CookieOptions
                        {

                            Expires = DateTime.Now.AddSeconds(300),

                            HttpOnly = true
                        };
                        Response.Cookies.Append("check", "true", cookieOptions);
                        return RedirectToAction("NewPassword");
                    }
                    else
                    {
                        ViewBag.NotMatchQues = "Question or Answer is wrong!";
                        return View();
                    }

                }
                else
                {
                    TempData["ErrorCookie"] = "Quá thời gian làm việc!";
                    return RedirectToAction("ForgotPassword");
                }

            }
            else
            {
                TempData["ErrorCookie"] = "Quá thời gian làm việc!";
                return RedirectToAction("ForgotPassword");
            }

        }

        public IActionResult NewPassword()
        {
            string? check = HttpContext.Request.Cookies["check"];
            if (check.Equals("false") || string.IsNullOrEmpty(check))
            {
                TempData["ErrorCookie"] = "Error";
                return RedirectToAction("ForgotPassword");
            }
            return View();
        }

        [HttpPost]
        public IActionResult NewPassword(string newPass, string renewPass)
        {
            if (!string.IsNullOrEmpty(newPass) && !string.IsNullOrEmpty(renewPass))
            {
                if (!newPass.Equals(renewPass))
                {
                    ViewBag.error = "Password and Re-Enter is not match";
                    return View();

                }

                string pattern = @"^(?=.*[a-zA-Z])(?=.*\d).{6,}$";
                if (Regex.IsMatch(newPass, pattern))
                {
                    // Mật khẩu hợp lệ
                    //string userJson = HttpContext.Session.GetString("UserToCheckQuesion");
                    string? userJson = HttpContext.Request.Cookies["UserToCheckQuesion"];
                    if (!string.IsNullOrEmpty(userJson))
                    {
                        var acc = JsonConvert.DeserializeObject<AccountModel>(userJson);
                        if (acc != null)
                        {
                            _accountRepository.UpdatePassword(acc.AccId, newPass);
                            Response.Cookies.Delete("UserToCheckQuesion");
                            Response.Cookies.Delete("check");
                            TempData["UpdatePass"] = "The new password has been saved. Please log in again.";
                            return RedirectToAction("Login", "Login");
                        }
                        else
                        {
                            TempData["ErrorCookie"] = "Quá thời gian làm việc!";
                            return RedirectToAction("ForgotPassword");
                        }

                    }
                    else
                    {
                        TempData["ErrorCookie"] = "Quá thời gian làm việc!";
                        return RedirectToAction("ForgotPassword");
                    }


                }
                else
                {
                    ViewBag.error = "Password must contain at least 1 letter and 1 number, with a minimum length of 6 characters.";
                    return View();
                }
            }
            else
            {
                ViewBag.error = "Password and Re-Password is require!";
            }
            return View();
        }

    }
}
