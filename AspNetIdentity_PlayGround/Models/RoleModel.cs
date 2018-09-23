using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetIdentity_PlayGround.Models
{
    public class RoleModel : IdentityRole
    {
        public string Desctiption { get; set; }
    }
}
