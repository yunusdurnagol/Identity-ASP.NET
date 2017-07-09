using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityFromZero.App_Start
{
    public class IdentityConfig
    {
        //IUser :Represent Individual user 
        //IUserStore : Where we save user data it is going to use EF Database Context object.
        //UserManager<> :For CRUD operations UserManager uses UserStore
        //SignInManager<> : In order to sign in a user it works with user to authenticate .

        //IdentityUser
        //UserStore<IdentityUser>: whenever we use user store we have to give DBContext to use
        //IdentityDbContext<IdentityUser>

    }
}