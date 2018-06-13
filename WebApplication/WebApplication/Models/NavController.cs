using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication.Models
{
    public class NavController : Controller
    {
        private AppDbContext db = new AppDbContext();
       
        public PartialViewResult Menu() {
            IEnumerable<string> categories = db.Products
                .Select(prd => prd.Category)
                .Distinct()
                .OrderBy(x => x);
            return PartialView(categories);
        }
    }
}
