using System.ComponentModel.DataAnnotations;

namespace SiteJointPurchase.Domain.Entities {
    public class Product {       
        [Key]
        public int Id { get; set; }
        [Display(Name = "Артикул")]
        public string Sku { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Цена (руб)")]
        public decimal Price { get; set; }
        [Display(Name = "Категория")]
        public string Category { get; set; }
        public byte[] ImageData { get; set; }
        public string ImageMimeType { get; set; }

    }
}