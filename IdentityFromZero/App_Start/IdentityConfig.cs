using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityFromZero.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;


namespace IdentityFromZero.App_Start
{
    public class ApplicationUserManager : UserManager<CustomUser>
    {
        public ApplicationUserManager(UserStore<CustomUser> userStore):base(userStore)
        {
                
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,IOwinContext context )
        {
            var userStore=new UserStore<CustomUser>(context.Get<ApplicationDbContext>());
            return new ApplicationUserManager(userStore);
        }
    }

    public class ApplicationSignInManager : SignInManager<CustomUser,string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager,IAuthenticationManager authenticationManager) : base(userManager,authenticationManager)
        {

        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            
            return new ApplicationSignInManager(context.Get<ApplicationUserManager>(),context.Authentication);
        }
    }

    public class ApplicationRoleManager : RoleManager<IdentityRole>
    {
        public ApplicationRoleManager(RoleStore<IdentityRole> store) : base(store)
        {

        }

        public static ApplicationRoleManager Create(IOwinContext context)
        {
            var store = new RoleStore<IdentityRole>(context.Get<ApplicationDbContext>());
            return new ApplicationRoleManager(store);
        }
    }



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