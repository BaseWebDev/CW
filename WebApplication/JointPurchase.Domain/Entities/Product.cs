using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteJointPurchase.Domain.Entities {
    public class Product {
        private string name;
        private decimal price;
        private string sku;

       

        public Product() {
        }
        public Product(string name, decimal price, string sku) {
            this.name = name;
            this.price = price;
            this.sku = sku;
        }
        
        [Key]
        public int Id { get; set; }
        public string Name { get=> name; set => name = value; }
        public decimal Price { get => price; set => price = value; }
        /// <summary>
        /// Артикул
        /// </summary>
        public string Sku { get => sku; set => sku = value; }

        public string Category { get; set; }
 
    }
}