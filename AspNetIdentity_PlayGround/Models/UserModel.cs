using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetIdentity_PlayGround.Models
{
    public class UserModel : IdentityUser
    {
        public string FullName { get; set; }
    }
}
