﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookieBasedSample.ViewModels
{
    public class RegisterViewModel
    {
        public string Email { set; get; }

        public string Password { set; get; }

        public string ConfirmPassword { set; get; }
    }
}
