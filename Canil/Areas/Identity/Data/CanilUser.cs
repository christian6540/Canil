﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Canil.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the CanilUser class
    public class CanilUser : IdentityUser
    {
        //[PersonalData]
        //[Column(TypeName = "varchar(100)")]
        //public string Username { get; set; }

        //[PersonalData]
        //[Column(TypeName = "varchar(100)")]
        //public string email { get; set; }

        //[PersonalData]
        //[Column(TypeName = "varchar(100)")]
        //public string password { get; set; }        
    }
}
