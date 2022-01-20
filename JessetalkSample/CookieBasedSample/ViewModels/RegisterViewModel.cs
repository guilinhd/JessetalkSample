using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CookieBasedSample.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Email { set; get; }

        [Required]
        public string Password { set; get; }

        [Required]
        public string ConfirmPassword { set; get; }
    }
}
