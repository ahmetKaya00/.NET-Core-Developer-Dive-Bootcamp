using System.ComponentModel.DataAnnotations;

namespace BooksApp.Models{

    public class Product{

        [Display(Name = "Ürün Id")]
        public int ProductId {get;set;}

        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Gerekli Alan")]
        [StringLength(100)]

        public string? Name {get;set;}

        [Display(Name = "Sayfa Sayısı")]
        [Required(ErrorMessage = "Gerekli Alan")]
        [Range(0,5000)]
        
        public decimal Pages {get;set;}

        [Display(Name = "Görsel")]
        public string? Image {get;set;} = string.Empty;
        public bool IsActive {get;set;}

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Gerekli Alan")]
        public int? CategoryId {get;set;}
    }
}