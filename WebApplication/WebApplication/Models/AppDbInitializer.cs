using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SiteJointPurchase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication.Models {
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext> {
        protected override void Seed(ApplicationDbContext context) {
            URLDate uRL1 = new URLDate(@"https://www.sima-land.ru/134480/narukavniki-neon-19h19-cm-ot-3-6-let-59640np-intex/", DateTime.Now);
            URLDate uRL2 = new URLDate(@"https://www.sima-land.ru/134262/skeytbord-pauk-kolesa-pvc-d-50-mm-cveta-miks/", DateTime.Now);
            URLDate uRL3 = new URLDate(@"https://www.sima-land.ru/134262/skeytbord-pauk-kolesa-pvc-d-50-mm-cveta-miks/", DateTime.Now);
            Product p1 = new Product(@"Лабораторные весы CAS MWP-150", 11563.96m, "3218078", uRL1);
            Product p2 = new Product(@"Лабораторные весы CAS MWP-150Лампа натриевая BELLIGHT ДНаЗ 600 Вт Е40/57 Агро BL, Е40/57, 85000лм, 380 В зеркальная", 115.00m, "5867011", uRL2);
            Product p3 = new Product(@"Ежедневник на скрытом гребне ""Россия"", экокожа, А5, 160 листов", 253.75m, "4213477", uRL3);
            Order ord1 = new Order();
            ord1.Add(p1, 10);
            ord1.Add(p2, 10);
            ord1.Add(p3, 10);
            Order ord2 = new Order();
            ord2.Add(p1, 20);
            ord2.Add(p2, 20);
            ord2.Add(p3, 30);
            Order ord3 = new Order();
            ord3.Add(p2, 30);


            Customer cust1 = new Customer();
            // Добавим список покупок
            cust1.Add(ord1);
            cust1.Add(ord3);

            Customer cust2 = new Customer();
            // Добавим логин пароль
            cust2.Add(ord2);

            context.Customers.Add(cust1);
            context.Customers.Add(cust2);


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
            admin.Customer = cust1;

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

            user.Customer = cust2;
            // если создание пользователя прошло успешно
            if (resultUser.Succeeded) {
                // добавляем для пользователя роль
                userManager.AddToRole(user.Id, role1.Name);
                userManager.AddToRole(user.Id, role2.Name);
            }

            base.Seed(context);

        }
    }
}