using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using IdentityFromZero.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityFromZero.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            //var context =new IdentityDbContext<IdentityUser>();
            var context = new ApplicationDbContext();
            var store =new UserStore<CustomUser>(context);
            var manager=new UserManager<CustomUser>(store);


            var email = "identity@identity.com";
            var password = "Password1234";
            var user = await manager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new CustomUser()
                {
                    UserName = email,
                    Email = email,
                    FirstName = "FirstName",
                    LastName = "LastName"
                };

                await manager.CreateAsync(user, password);
            }
            else
            {
                user.FirstName = "FirstName";
                user.LastName = "LastName";
                await manager.UpdateAsync(user);
            }


            return Content("Hello You are on home page");
        }
    }
}