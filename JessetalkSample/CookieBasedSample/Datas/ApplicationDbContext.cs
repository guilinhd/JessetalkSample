
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CookieBasedSample.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CookieBasedSample.Datas
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {

        }

        private DbSet<ApplicationUser> ApplicationUser { set; get; }

        

        public DbSet<ApplicationRole> ApplicationRoles { set; get; }
    }
}
