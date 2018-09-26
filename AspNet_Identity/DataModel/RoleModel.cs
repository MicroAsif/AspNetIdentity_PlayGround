using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspNet_Identity.DataModel
{
    public class RoleModel : IdentityRole
    {
        public string Description { get; set; }
    }
}
