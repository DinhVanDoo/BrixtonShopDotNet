using Brixton.Interfaces;
using Brixton.Models;
using Brixton.Repository;
using Brixton.Validator;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Brixton.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IOrderRepository _orderRepository;

        public CustomerController(IAccountRepository accountRepository, IOrderRepository orderRepository)
        {
            _accountRepository = accountRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Profile(string? accid)
        {
            AccountModel model = new AccountModel();

            model = _accountRepository.getAccountByAccID(accid);

            return View(model);
        }

        public IActionResult UpdateProfile(string accid)
        {
            AccountModel model = new AccountModel();
            if (accid != null)
            {
                model = _accountRepository.getAccountByAccID(accid);
                return View(model);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult UpdateProfile(string accid, AccountModel accountModel)
        {
            var validator = new AccountValidate();
            var result = validator.Validate(accountModel);


            if (result.IsValid)
            {
                _accountRepository.UpdateInfoModel(accid, accountModel);
                AccountModel model = _accountRepository.getAccountByAccID(accid);
                string userJson = JsonConvert.SerializeObject(model);
                HttpContext.Session.SetString("User", userJson);
                ViewBag.Success = "Update Successful!";
            }

            return View(accountModel);
        }

        public IActionResult HistoryOrder()
        {
            string? accJson = HttpContext.Session.GetString("User");
            AccountModel acc = JsonConvert.DeserializeObject<AccountModel>(accJson);

            List<OrderHe161048> list = _orderRepository.GetOrder(acc.AccId);
            ViewBag.Acc = acc;
            return View(list);
        }

        public IActionResult OrderDetail(int OrId)
        {


            List<OrderDetailHe161048> list = _orderRepository.GetOrderDetail(OrId);

            return View(list);
        }




    }
}
