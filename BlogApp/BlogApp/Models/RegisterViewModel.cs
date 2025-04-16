﻿using System.ComponentModel.DataAnnotations;

namespace BlogApp.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı alanı zorunludur.")]
        [MinLength(8, ErrorMessage = "Kullanıcı adı en az 6 karakter olmalıdır.")]
        [MaxLength(25, ErrorMessage = "Kullanıcı adı en fazla 25 karakter olmalıdır.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre alanı zorunludur.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; }
    }
}
