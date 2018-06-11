using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication.Models {
    public class ApplicationContext : IdentityDbContext<ApplicationUser> {
        public ApplicationContext() : base("JointPurchase") { }

        public static ApplicationContext Create() {
            return new ApplicationContext();
        }
    }
}