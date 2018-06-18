using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace SiteJointPurchase.Domain.Entities {
    public class JointPurchase {
        public int MinQuantity = 1000;
        [Key]
        public int Id { get; set; }
        public List<Order> Orders { get; set; }

        public JointPurchase() {
            Orders = new List<Order>();
        }
        public void Add(Order ord) {
            Orders.Add(ord);
        }
        public decimal GetTotal() {
            decimal total = 0;
            foreach (var order in Orders) {
                total += order.GetTotal();
            }
            return total;
        }
        public int GetTotalQuantity() {
            int total = 0;
            foreach (var cart in Orders) {
                foreach (var item in cart.Items) {
                    total += item.Quantity;
                }
            }
            return total;
        }
    }
}