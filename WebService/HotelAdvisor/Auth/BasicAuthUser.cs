using HotelAdvisor.Models;

namespace HotelAdvisor.Auth
{
    public static class BasicAuthUser
    {
        public static ApplicationUser GetCurrent()
        {
            return BasicAuthHelper.GetApplicationUser();
        }
    }
}