﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SCore.Models
{
    public class User : IdentityUser
    {

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Input you name")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Input you surname")]
        public string LastName { get; set; }

        [Display(Name = "Register date")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfRegister { get; set; } = DateTime.Now;

        public virtual ICollection<Order> Orders { get; set; }
        public User()
        {

        }
    //    public async Task<ClaimsIdentity> GenerateUserIdentityAsync(
    //UserManager<User> manager)
    //    {
    //        // Note the authenticationType must match the one 
    //        // defined in CookieAuthenticationOptions.AuthenticationType
    //        var userIdentity =
    //            await manager.CreateIdentityAsync(this,
    //                DefaultAuthenticationTypes.ApplicationCookie);
    //        // Add custom user claims here
    //        return userIdentity;
    //    }
    }
}
