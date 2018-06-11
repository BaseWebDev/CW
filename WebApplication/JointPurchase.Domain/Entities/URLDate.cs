using System;
using System.ComponentModel.DataAnnotations;

namespace SiteJointPurchase.Domain.Entities {
    public class URLDate {
        private string url;
        private DateTime dateTime;
        public URLDate() {
        }
        public URLDate(string url, DateTime dateTime) {
            this.url = url;
            this.dateTime = dateTime;
        }
        [Key]
        public int Id { get; set; }
        public string URL { get => url; set => url = value; }
        public DateTime DateTimeGetURL { get => dateTime; set => dateTime = value; }
       // public int ProductId { get; set; }
    }
}