using System.Web;
using HotelAdvisor;
using HotelAdvisor.Auth;
using Microsoft.Owin;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Owin;

[assembly: PreApplicationStartMethod(typeof(FormsAuthenticationFixer), "Start")]

[assembly: OwinStartupAttribute(typeof(HotelAdvisor.Startup))]

namespace HotelAdvisor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }

    public static class FormsAuthenticationFixer
    {
        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(AjaxFormsAuthenticationModule));
        }
    }
}
