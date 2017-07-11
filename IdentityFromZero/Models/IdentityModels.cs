using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityFromZero.Models
{
    public class ApplicationDbContext:IdentityDbContext<CustomUser>
    {

        public ApplicationDbContext():base()
        {
                
        }

        public static ApplicationDbContext Create()
        {
            return  new ApplicationDbContext();
        }

    }
    public class CustomUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public static class SecurityRole
    {
        public const string Admin = "admin";
        public const string SuperAdmin = "superadmin";
    }       
}