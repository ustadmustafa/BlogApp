using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{

    public class Blog
    {
        public int Id { get; set; }

        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [MinLength(3, ErrorMessage = "Başlık en az 3 karakter olmalıdır.")]
        [MaxLength(100, ErrorMessage = "Başlık en fazla 100 karakter olabilir.")]
        public string Title { get; set; }

        [Display(Name = "İçerik")]
        [Required(ErrorMessage = "İçerik alanı zorunludur.")]
        [MinLength(10, ErrorMessage = "İçerik en az 10 karakter olmalıdır.")]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [Required(ErrorMessage = "Kullanıcı bilgisi gereklidir.")]
        public int UserId { get; set; }

        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "Kategori seçimi zorunludur.")]
        public int CategoryId { get; set; }

        [Display(Name = "Yayın Tarihi")]
        [Required(ErrorMessage = "Yayın tarihi zorunludur.")]
        [DataType(DataType.DateTime)]
        public string PublishDate { get; set; }

    }
}
