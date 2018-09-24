using System;
using System.Collections.Generic;
using System.Text;
using AspNetIdentity_PlayGround.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetIdentity_PlayGround.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel, RoleModel, string>
    {

       
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
        
        protected override void OnModelCreating(ModelBuilder builder)
        {

            
            
            base.OnModelCreating(builder);
        }
    }
}
