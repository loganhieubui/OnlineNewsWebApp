﻿using System.ComponentModel.DataAnnotations;

namespace OnlineNews.MVCWebApp.Models
{
    public class LoginViewModel
    {
        [Required]        
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
