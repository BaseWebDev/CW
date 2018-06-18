using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace WebApplication.Models {
    public class ApplicationManager : UserManager<ApplicationUser> {
        public ApplicationManager(IUserStore<ApplicationUser> store) : base(store) {
        }
        public static ApplicationManager Create(IdentityFactoryOptions<ApplicationManager> options,
                                            IOwinContext context) {
            AppDbContext db = context.Get<AppDbContext>();
            ApplicationManager manager = new ApplicationManager(new UserStore<ApplicationUser>(db));
            return manager;
        }
    }
}