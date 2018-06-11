using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiteJointPurchase.Domain.Entities {
    public class Customer {
        [Key]
        public int Id { get; set; }
        private List<Order> orders = new List<Order>(); 
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string MiddleName { get; set; }
        /// <summary>
        /// Телефон для связи
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// Учетная запись на сайте
        /// </summary>
       // [Required]
      //  public User User { get; set; }

        public List<Order> Orders { get => orders; set => orders=value; }

        public void Add(Order ord) {
            orders.Add(ord);
        }

    }
}