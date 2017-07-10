using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdentityFromZero.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace IdentityFromZero.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            //var context =new IdentityDbContext<IdentityUser>();
            //var context = new ApplicationDbContext();
            //var store =new UserStore<CustomUser>(context);
            //var manager=new UserManager<CustomUser>(store);
            //var signInManager =new SignInManager<CustomUser, string>
            //    (manager, HttpContext.GetOwinContext().Authentication);


            var email = "identity@identity.com";
            var password = "Password1234";
            var user = await UserManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new CustomUser()
                {
                    UserName = email,
                    Email = email,
                    FirstName = "FirstName",
                    LastName = "LastName"
                };

                await UserManager.CreateAsync(user, password);
            }
            else
            {
                var result = await SignInManager.PasswordSignInAsync(user.UserName, password, true,false);
                if (result == SignInStatus.Success)
                {
                    return Content("Hello"+user.FirstName+" "+user.LastName);
                }
                //user.FirstName = "FirstName";
                //user.LastName = "LastName";
                //await manager.UpdateAsync(user);
            }


            return Content("Hello You are on home page");
        }
    }
}