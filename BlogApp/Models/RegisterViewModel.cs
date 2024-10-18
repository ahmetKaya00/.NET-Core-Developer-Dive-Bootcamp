using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models{

    public class RegisterViewModel{

        [Display(Name = "UserName")]
        [Required]
        public string? UserName {get;set;}

        [Display(Name = "Ad Soyad")]
        [Required]
        public string? Name {get;set;}

        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string? Email {get;set;}
        [Required]
        [StringLength(10, ErrorMessage = "{0} alanı en az {2} karakter uzunluğunda olmalıdır.",MinimumLength =6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string? Password {get;set;}

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parola Tekrar")]
        [Compare(nameof(Password),ErrorMessage = "Parolanız eşleşmiyor")]
        public string? ConfirmPassword {get;set;}
    }
}