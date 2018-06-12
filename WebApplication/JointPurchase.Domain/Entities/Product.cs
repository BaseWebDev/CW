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
        [Display(Name = "Название")]
        public string Name { get=> name; set => name = value; }
        [Display(Name = "Цена (руб)")]
        public decimal Price { get => price; set => price = value; }
        [Display(Name = "Артикул")]
        public string Sku { get => sku; set => sku = value; }
        [Display(Name = "Категория")]
        public string Category { get; set; }

        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

    }
}