using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteJointPurchase.Domain.Entities {
    public class JointPurchase {
        public int Id { get; set; }
        private List<Cart> orders = new List<Cart>();
        public List<Cart> Orders { get => orders; set => orders = value; }
        public void Add(Cart order) {
            orders.Add(order);
        }
        public decimal GetTotal() {
            decimal total = 0;
            foreach (var order in orders) {
                total += order.GetTotal();
            }
            return total;
        }
    }
}