using System.Web.Http;
using System.Web.Http.Controllers;

namespace HotelAdvisor.Auth
{
    public class BasicAuthAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            return true;
        }
    }
}