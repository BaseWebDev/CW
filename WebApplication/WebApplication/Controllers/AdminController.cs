using SiteJointPurchase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin
        // Доступ только для админа
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View(db.Products);
        }
        // Доступ только для админа
        [Authorize(Roles = "admin")]
        public ViewResult Edit(int Id) {
            Product prd = db.Products
                .FirstOrDefault(g => g.Id == Id);
            return View(prd);
        }
        // Перегруженная версия Edit() для сохранения изменений
        // Доступ только для админа
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Edit(Product prd) {
            if (ModelState.IsValid) {
                SaveProduct(prd);
                TempData["message"] = string.Format("Изменения в товаре \"{0}\" были сохранены", prd.Name);
                return RedirectToAction("Index");
            } else {
                // Что-то не так со значениями данных
                return View(prd);
            }
        }
        // Доступ только для админа
        [Authorize(Roles = "admin")]
        public ViewResult Create() {
            return View("Edit", new Product());
        }
        // Доступ только для админа
        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult Delete(int Id) {
            Product prd = DeleteProduct(Id);
            if (prd != null) {
                TempData["message"] = string.Format("Товар \"{0}\" был удален",
                    prd.Name);
            }
            return RedirectToAction("Index");
        }
        // Доступ только для админа
        [Authorize(Roles = "admin")]
        void SaveProduct(Product prd) {
            if (prd.Id == 0)
                db.Products.Add(prd);
            else {
                Product dbEntry = db.Products.Find(prd.Id);
                if (dbEntry != null) {
                    dbEntry.Name = prd.Name;
                    dbEntry.Sku = prd.Sku;
                    dbEntry.Price = prd.Price;
                    dbEntry.Category = prd.Category;
                }
            }
            db.SaveChanges();
        }
        // Доступ только для админа
        [Authorize(Roles = "admin")]
        public Product DeleteProduct(int Id) {
            Product prd = db.Products.Find(Id);
            if (prd != null) {
                db.Products.Remove(prd);
                db.SaveChanges();
            }
            return prd;
        }
    }
}