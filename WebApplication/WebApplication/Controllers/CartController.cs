using SiteJointPurchase.Domain.Abstract;
using SiteJointPurchase.Domain.Concrete;
using SiteJointPurchase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class CartController : Controller {

        private ApplicationDbContext db = new ApplicationDbContext();
        private IOrderProcessor orderProcessor= new EmailOrderProcessor(new EmailSettings());

        //public CartController(IOrderProcessor processor) {
        //    orderProcessor = processor;
        //}

        public ViewResult Index(Cart cart, string returnUrl) {
            return View(new CartIndexViewModel {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int Id, string returnUrl) {  // Id интерпретируется дословно
            Product prd = db.Products
                .FirstOrDefault(g => g.Id == Id);

            if (prd != null) {
                cart.AddItem(prd, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int Id, string returnUrl) {
            Product prd = db.Products
               .FirstOrDefault(g => g.Id == Id);

            if (prd != null) {
                cart.RemoveItem(prd);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        [Authorize]
        public ViewResult Checkout() {
            return View(new ShippingDetails());
        }
        [HttpPost]
        [Authorize]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails) {
            if (cart.Items.Count() == 0) {
                ModelState.AddModelError("", "Извините, ваша корзина пуста!");
            }

            if (ModelState.IsValid) {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            } else {
                return View(shippingDetails);
            }
        }


        public PartialViewResult Summary(Cart cart) {
            return PartialView(cart);
        }
    }
}