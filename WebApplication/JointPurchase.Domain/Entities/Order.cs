﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteJointPurchase.Domain.Entities {
    /// <summary>
    /// Заказ
    /// </summary>
    public class Order {
        [Key]
        public int Id { get; set; }
        private List<Item> items = new List<Item>();       
        public List<Item> Items { get=> items; set => items=value; }
        public Customer Customer { get; set; }
        public void Add(Product p, int qty) {
            Item item = new Item(p, qty);
            items.Add(item);
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