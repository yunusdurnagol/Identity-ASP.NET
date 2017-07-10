using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IdentityFromZero.App_Start;
using IdentityFromZero.Models;

[assembly:OwinStartupAttribute(typeof(IdentityFromZero.Startup))]
namespace IdentityFromZero
{
    public class Startup
    {
        //That is where we configure identity we would fill it later
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(ApplicationDbContext.Create);
            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
        }
    }
}