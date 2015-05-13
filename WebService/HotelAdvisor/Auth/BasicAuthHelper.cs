using System;
using System.Linq;
using System.Text;
using System.Web;
using HotelAdvisor.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Newtonsoft.Json;

namespace HotelAdvisor.Auth
{
    public static class BasicAuthHelper
    {
        public static BasicAuthModel GetCurrent()
        {
            string parameters = HttpContext.Current.Request.Headers["Authorization"];
            if (parameters != null)
            {
                try
                {
                    string token = parameters.Split()[1];
                    string usernameAndPass = Encoding.UTF8.GetString(Convert.FromBase64String(token));
                    var parts = usernameAndPass.Split(":".ToCharArray());
                    return new BasicAuthModel
                    {
                        Username = parts[0],
                        Password = string.Join(":", parts.Skip(1))
                    };
                }
                catch
                {
                    return null;
                }
            }
            return null;
        }

        private static ApplicationUserManager UserManager
        {
            get { return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }

        public static ApplicationUser GetApplicationUser()
        {
            try
            {
                var user = GetCurrent();
                if (user == null)
                {
                    return null;
                }
                if (string.IsNullOrEmpty(user.Username))
                {
                    return null;
                }
                return UserManager.Find(user.Username, user.Password);
            }
            catch
            {
                return null;
            }
        }
    }
}