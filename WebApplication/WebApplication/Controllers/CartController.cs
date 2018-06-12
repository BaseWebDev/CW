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

        public ViewResult Index(string returnUrl) {
            return View(new CartIndexViewModel {
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(int productId, string returnUrl) {
            Product prd = db.Products
                .FirstOrDefault(g => g.Id == productId);

            if (prd != null) {
                GetCart().AddItem(prd, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult RemoveFromCart(int productId, string returnUrl) {
            Product prd = db.Products
               .FirstOrDefault(g => g.Id == productId);

            if (prd != null) {
                GetCart().RemoveItem(prd);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public Order GetCart() {
            Order cart = (Order)Session["Cart"];
            if (cart == null) {
                cart = new Order();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}