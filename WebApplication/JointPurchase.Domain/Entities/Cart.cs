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
        private List<Item> items = new List<Item>();       
        public List<Item> Items { get => items; set => items = value; }
        public Customer Customer { get; set; }
        public void AddItem(Product p, int qty) {
            
            //Item line = items
            //    .Where(prd => prd.Product.Id == p.Id)
            //    .FirstOrDefault();
            //if (line == null) {
                Item item = new Item(p, qty);
                items.Add(item);
            //} else {
            //    line.Quantity += qty;
            //}
        }
        public void RemoveItem(Product p) {
            items.RemoveAll(prd => prd.Product.Id == p.Id);
        }
        public void Clear() {
            items.Clear();
        }

        public decimal GetTotal() {
            decimal total = 0;
            foreach (var item in items) {
                Product p = item.Product;
                int qty = item.Quantity;
                total += p.Price * qty;
            }
            return total;
        }
    }
}