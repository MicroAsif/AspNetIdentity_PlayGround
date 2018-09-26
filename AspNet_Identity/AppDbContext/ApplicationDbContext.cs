using AspNet_Identity.DataModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNet_Identity.AppDbContext
{
    class ApplicationDbContext : IdentityDbContext<UserModel, RoleModel, string>
    {
    }
}
