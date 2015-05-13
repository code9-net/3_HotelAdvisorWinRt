using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelAdvisor.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HotelAdvisor.Auth
{
    public static class BasicAuthUser
    {
        public static ApplicationUser GetCurrent(IdentityDbContext<ApplicationUser> dbContext)
        {
            return null;
        }
    }
}