using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IdentityFromZero.App_Start;
using Microsoft.AspNet.Identity.Owin;


namespace IdentityFromZero.Controllers
{
    public abstract class BaseController : Controller
    {
        public ApplicationUserManager UserManager
        {
            get { return HttpContext.GetOwinContext().Get<ApplicationUserManager>(); }
        }

        public ApplicationSignInManager SignInManager
        {
            get { return HttpContext.GetOwinContext().Get<ApplicationSignInManager>(); }
        }
    }
}