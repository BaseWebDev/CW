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

        private URLDate uRLDate;


        public Product() {
        }
        public Product(string name, decimal price, string sku) {
            this.name = name;
            this.price = price;
            this.sku = sku;
        }
        public Product(string name, decimal price, string sku, URLDate uRLDate) : this(name, price, sku) {
            this.uRLDate = uRLDate;
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

        public virtual URLDate URLDate { get => uRLDate; set => uRLDate = value; }
        
    }
}