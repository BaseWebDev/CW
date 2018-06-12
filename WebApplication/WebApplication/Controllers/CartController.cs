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

        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails) {
            return View(new ShippingDetails());
        }

        public PartialViewResult Summary(Cart cart) {
            return PartialView(cart);
        }
    }
}