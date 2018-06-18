using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteJointPurchase.Domain.Entities {
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order {
        public int Id { get; set; }
        public List<Item> Items { get; set; }
        public Customer Customer { get; set; }
        public JointPurchase JointPurchase { get; set; }
        public Order() {
            Items = new List<Item>();
        }

        public void Paid(Cart cart, Customer cust) {
            this.Items = cart.Items;
            this.Customer = cust;
        }
        public decimal GetTotal() {
            decimal total = 0;
            foreach (var item in Items) {
                Product p = item.Product;
                int qty = item.Quantity;
                total += p.Price * qty;
            }
            return total;
        }
    }
}
