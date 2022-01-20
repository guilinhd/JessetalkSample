using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace CookieBasedSample.Models
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
    }
}
