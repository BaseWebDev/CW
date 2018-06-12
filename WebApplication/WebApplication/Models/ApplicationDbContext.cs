using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using SiteJointPurchase.Domain.Entities;

namespace WebApplication.Models {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<JointPurchase> JointPurchases { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Product> Products { get; set; }
        
        public ApplicationDbContext()
            : base("JointPurchase", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
       
    }
}