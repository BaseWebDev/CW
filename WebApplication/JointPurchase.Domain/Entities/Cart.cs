using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteJointPurchase.Domain.Entities {
    /// <summary>
    /// Заказ
    /// </summary>
    public class Cart {
        [Key]
        public int Id { get; set; }
       public List<Item> Items { get; set; }
        public Customer Customer { get; set; }
        public Cart() {
            Items = new List<Item>();
        }
        public void AddItem(Product p, int qty) {
            Items.Add(new Item(p, qty));
        }
        public void RemoveItem(Product p) {
            Items.RemoveAll(prd => prd.Product.Id == p.Id);
        }
        public void Clear() {
            Items.Clear();
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