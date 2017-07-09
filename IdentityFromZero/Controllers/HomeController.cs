using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace IdentityFromZero.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public async Task<ActionResult> Index()
        {
            var context =new IdentityDbContext<IdentityUser>();
            var store=new UserStore<IdentityUser>(context);
            var manager=new UserManager<IdentityUser>(store);


            var email = "identity@identity.com";
            var password = "Password1234";
            var user = await manager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new IdentityUser()
                {
                    UserName = email,
                    Email = email
                };

                await manager.CreateAsync(user, password);
            }


            return Content("Hello You are on home page");
        }
    }
}