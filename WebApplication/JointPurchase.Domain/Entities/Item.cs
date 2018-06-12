using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteJointPurchase.Domain.Entities {
    public class Item {
       
        private Product product;
        private int quantity;

        [Key]
        public int Id { get; set; }
        public Product Product { get => product; set => product = value; }
        [Required]
        public int Quantity { get => quantity; set => quantity = value; }
        public Cart Order { get; set; }
        public Item() { }
        /// <summary>
        /// Кол-во товара
        /// </summary>
        /// <param name="product">товар</param>
        /// <param name="quantity">кол-во</param>
        public Item(Product product, int quantity) {
            this.product = product;
            this.quantity = quantity;
        }
      
    }
}