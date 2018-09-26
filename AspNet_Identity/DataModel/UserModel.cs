using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspNet_Identity.DataModel
{
    public class UserModel : IdentityUser
    {
        [DisplayName("Full Name")]
        [Required]
        public string FullName { get; set; }
    }
}
