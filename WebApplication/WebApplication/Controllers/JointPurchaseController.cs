using System.Linq;
using System.Web.Mvc;
using SiteJointPurchase.Domain.Entities;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class JointPurchaseController : Controller
    {
        private AppDbContext db = new AppDbContext();
        public PartialViewResult Joint() {
            return PartialView(NewOrOldJoint());
        }

        public JointPurchase NewOrOldJoint() {
            JointPurchase joint = db.JointPurchases
                              .Where(j => j.Id == db.JointPurchases
                               .Max(x => x.Id))
                               .FirstOrDefault();
            int itemCount=db.Orders.Where(x => x.JointPurchase.Id == joint.Id).Count();
            if (itemCount > 0) {
                int jointSum = db.Orders
                    .Where(x => x.JointPurchase.Id == joint.Id)
                    .SelectMany(q => q.Items)
                    .Sum(s=>s.Quantity);
                if (jointSum > joint.MinQuantity) {
                    joint = new JointPurchase();
                    db.JointPurchases.Add(joint);
                    db.SaveChanges();
                }
            }
                return joint;
        }
    }
}