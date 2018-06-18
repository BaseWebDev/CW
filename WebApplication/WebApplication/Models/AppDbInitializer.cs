using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SiteJointPurchase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.IO;

namespace WebApplication.Models {
   
    public class AppDbInitializer : DropCreateDatabaseAlways<AppDbContext> {
        const string imageDir = @"D:\Code\BaseWebDev\CW\WebApplication\WebApplication\Images\";
        protected override void Seed(AppDbContext context) {
            int i = 0;
            Product p1 = new Product() {
                Sku = "34568"+(i++).ToString(),
                Name = "Перкаль 60 см",
                Price = 120.24m,
                Category = "Перкаль"
            };
            AddImage(p1, imageDir+@"18646v1.jpg");
            Product p2 = new Product() {
                Sku = "34568" + (i++).ToString(),
                Name = "Сатин 120 см",
                Price = 224.00m,
                Category = "Сатин"
            };
            AddImage(p2, imageDir + @"18646v2.jpg");
            Product p3 = new Product() {
                Sku = "34568" + (i++).ToString(),
                Name = "Перкаль 60 см",
                Price = 120.24m,
                Category = "Перкаль"
            };
            AddImage(p3, imageDir + @"18694v3.jpg");

            Product p4 = new Product() {Sku = "34568" + (i++).ToString(), Name = @"Бязь ""Лайт"" 60 см",Price = 60.24m, Category = "Бязь" };
            AddImage(p4, imageDir + @"18694v4.jpg");
            context.Products.Add(p4);
            Product p5 = new Product() { Sku = "34568" + (i++).ToString(), Name = @"Бязь ""Премиум"" 60 см", Price = 60.24m, Category = "Бязь" };
            AddImage(p5, imageDir + @"18767v2.jpg");
            context.Products.Add(p5);
            Product p6 = new Product() { Sku = "34568" + (i++).ToString(), Name = @"Бязь ""Комфорт"" 80 см", Price = 95.16m, Category = "Бязь" };
            AddImage(p6, imageDir + @"18774v1.jpg");
            context.Products.Add(p6);
            Product p7 = new Product() { Sku = "34568" + (i++).ToString(), Name = @"Бязь ""Люкс"" 60 см", Price = 56.77m, Category = "Бязь" };
            AddImage(p7, imageDir + @"18774v3.jpg");
            context.Products.Add(p7);
            Product p8 = new Product() { Sku = "34568" + (i++).ToString(), Name = @"Бязь ""Экстра"" 220 см", Price = 134.64m, Category = "Бязь" };
            AddImage(p8, imageDir + @"18810v1.jpg");
            context.Products.Add(p8);
            Product p9 = new Product() { Sku = "34568" + (i++).ToString(), Name = @"Бязь ""Ультра"" 60 см", Price = 46.17m, Category = "Бязь" };
            AddImage(p9, imageDir + @"18846v 6.jpg");
            context.Products.Add(p9);
            Product p10 = new Product() { Sku = "34568" + (i++).ToString(), Name = @"Бязь ""ГОСТ"" 120 см", Price = 90.72m, Category = "Бязь" };
            AddImage(p10, imageDir + @"18846v9.jpg");
            context.Products.Add(p10);



            Cart cart1 = new Cart();
            cart1.AddItem(p1, 10);
            cart1.AddItem(p2, 10);
            cart1.AddItem(p3, 10);
            Cart cart2 = new Cart();
            cart2.AddItem(p1, 20);
            cart2.AddItem(p2, 20);
            cart2.AddItem(p3, 30);
            Cart cart3 = new Cart();
            cart3.AddItem(p2, 30);

         

            Customer cust1 = new Customer();
            context.Customers.Add(cust1);

            Customer cust2 = new Customer();          
            context.Customers.Add(cust2);

            Order ord = new Order();
            ord.Paid(cart1,cust1);
            ord.Paid(cart2,cust2);
            context.Orders.Add(ord);

            JointPurchase joint = new JointPurchase();
            joint.Add(ord);
            context.JointPurchases.Add(joint);

            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            // создаем две роли
            var role1 = new IdentityRole { Name = "admin" };
            var role2 = new IdentityRole { Name = "user" };

            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);

            // создаем пользователей
            var admin = new ApplicationUser { Email = "antonsermus@mail.ru", UserName = "antonsermus@mail.ru" };
            string passwordAdmin = "Alskd43764q@";
            var resultAdmin = userManager.Create(admin, passwordAdmin);
            admin.CustomerId = cust1.Id;

            // если создание пользователя прошло успешно
            if (resultAdmin.Succeeded) {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
            }
            // создаем пользователей
            var user = new ApplicationUser { Email = "user@mail.ru", UserName = "user@mail.ru" };
            string passwordUser = "S123456gjTgr&^";
            var resultUser = userManager.Create(user, passwordUser);

            user.CustomerId = cust2.Id;
            // если создание пользователя прошло успешно
            if (resultUser.Succeeded) {
                // добавляем для пользователя роль
                userManager.AddToRole(user.Id, role1.Name);
                userManager.AddToRole(user.Id, role2.Name);
            }

            base.Seed(context);

        }

        private void AddImage(Product p, string imageFile) {     
            if (File.Exists(imageFile)) {
                p.ImageData = File.ReadAllBytes(imageFile);
                p.ImageMimeType = MimeMapping.GetMimeMapping(imageFile);
            }
        }
    }
}