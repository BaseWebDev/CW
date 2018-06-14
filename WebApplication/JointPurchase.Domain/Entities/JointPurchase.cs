using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteJointPurchase.Domain.Entities {
    public class JointPurchase {
        public int Id { get; set; }
        public List<Cart> Carts { get; set; }
        public void Add(Cart order) {
            Carts.Add(order);
        }
        public decimal GetTotal() {
            decimal total = 0;
            foreach (var cart in Carts) {
                total += cart.GetTotal();
            }
            return total;
        }
        public int GetTotalQuantity() {
            int total = 0;
            foreach (var cart in Carts) {
                foreach (var item in cart.Items) {
                    total += item.Quantity;
                }
            }
            return total;
        }
    }
}