using HotelAdvisor.Auth;
using HotelAdvisor.Windows.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Microsoft.AspNet.Identity.Owin;
using HotelAdvisor.Models;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace HotelAdvisor.Controllers
{
    public class AuthController : ApiController
    {
        public ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        [HttpGet, BasicAuth]
        public bool Validate()
        {
            return true;
        }

        [HttpPost]
        public async Task<bool> Register([FromBody]RegisterModel model)
        {
            var user = new ApplicationUser() { UserName = model.Username, Email = model.Username };
            IdentityResult result = await UserManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return true;
            }
            throw new HttpResponseException(HttpStatusCode.Unauthorized);
        }
    }
}
