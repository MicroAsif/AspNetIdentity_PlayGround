using AspNet_Identity.DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNet_Identity.AppDbContext
{
    public class ApplicationDbContext : IdentityDbContext<UserModel, RoleModel, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<Category> Categories { get; set; }



    }
}
