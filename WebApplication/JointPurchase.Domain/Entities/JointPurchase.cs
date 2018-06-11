using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteJointPurchase.Domain.Entities {
    public class JointPurchase {
        public int Id { get; set; }
        private List<Order> orders = new List<Order>();
        public List<Order> Orders { get => orders; set => orders = value; }
        public void Add(Order order) {
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