using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using System.Security.Principal;


namespace CookieBasedSample.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult MyLogin()
        {
            var claims = new List<Claim>() {
                new Claim(ClaimTypes.Name, "molw"),
                new Claim(ClaimTypes.Role, "admin")
            };

            IIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
            
            return Ok();
        }

        public IActionResult MyLogout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }
    }
}
