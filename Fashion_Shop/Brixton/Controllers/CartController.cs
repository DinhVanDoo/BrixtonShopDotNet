using Brixton.Models;
using Brixton.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using Newtonsoft.Json;
using System.Text.Json;
using System;
using Brixton.Interfaces;

namespace Brixton.Controllers
{
    public class CartController : Controller
    {
        public Cart? cart { get; set; }
        private readonly IProductRepository _productRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IOrderRepository _orderRepository;

        public CartController(IProductRepository productRepository, IAccountRepository accountRepository, IOrderRepository orderRepository)
        {

            _productRepository = productRepository;
            _accountRepository = accountRepository;
            _orderRepository = orderRepository;
        }

        public IActionResult Cart()
        {
            string? cartJson = HttpContext.Session.GetString("Cart");
            string? accJson = HttpContext.Session.GetString("User");
            if (!string.IsNullOrEmpty(cartJson) && !string.IsNullOrEmpty(accJson))
            {
                Cart? cart = JsonConvert.DeserializeObject<Cart>(cartJson);
                HttpContext.Session.SetString("Cart_Number", cart._items.Count.ToString());
                ViewBag.Total_Money = cart.getTotalMoney().ToString();
                AccountModel acc = JsonConvert.DeserializeObject<AccountModel>(accJson);
                ViewBag.Account = acc;
                return View(cart);
            }

            if (!string.IsNullOrEmpty(cartJson) && string.IsNullOrEmpty(accJson))
            {
                Cart? cart = JsonConvert.DeserializeObject<Cart>(cartJson);
                HttpContext.Session.SetString("Cart_Number", cart._items.Count.ToString());
                ViewBag.Total_Money = cart.getTotalMoney().ToString();

                return View(cart);
            }
            Cart emp = new Cart();
            try
            {

                AccountModel acc = JsonConvert.DeserializeObject<AccountModel>(accJson);
                ViewBag.Account = acc;
            }
            catch (Exception ex)
            {

            }
            return View(emp);
        }


        public IActionResult AddToCart(int proID, int quantity)
        {

            ProductModel? product = _productRepository.getProductById(proID);
            if (product != null)
            {
                string? cartJson = HttpContext.Session.GetString("Cart");
                if (string.IsNullOrEmpty(cartJson))
                {
                    cart = new Cart();
                }
                else
                {
                    cart = JsonConvert.DeserializeObject<Cart>(cartJson);
                }

                if ((quantity == -1) && (cart.getQuantityById(proID) <= 1))
                {
                    cart.removeItem(proID);
                }
                else
                {
                    cart.AddItem(product, quantity);

                }
                string newcart = JsonConvert.SerializeObject(cart);
                HttpContext.Session.SetString("Cart", newcart);

            }

            return RedirectToAction("Cart");

        }

        public IActionResult Checkout()
        {

            string? cartJson = HttpContext.Session.GetString("Cart");
            if (cartJson == null)
            {
                return RedirectToAction("ShopAll", "Shop");
            }
            cart = JsonConvert.DeserializeObject<Cart>(cartJson);

            string? accJson = HttpContext.Session.GetString("User");

            if (accJson != null)
            {
                AccountModel? acc = JsonConvert.DeserializeObject<AccountModel>(accJson);
                _orderRepository.Checkout(cart, acc);
                HttpContext.Session.Remove("Cart");
                HttpContext.Session.Remove("Cart_Number");
                return RedirectToAction("Home", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Login");
            }


        }


    }
}
