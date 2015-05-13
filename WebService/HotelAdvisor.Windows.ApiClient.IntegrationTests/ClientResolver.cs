using System;

namespace HotelAdvisor.Windows.ApiClient.IntegrationTests
{
    internal static class ClientResolver
    {
        private const string Username = "admin@admin.com";
        private const string Password = "Admin@123";

        public static HotelClient GetHotelClient()
        {
            return new HotelClient(Username, Password);
        }

        public static CommentsClient GetCommentsClient()
        {
            return new CommentsClient(Username, Password);
        }

        public static TestAuthClient GetTestAuthClient()
        {
            return new TestAuthClient(Username, Password);
        }

        public static TestAuthClient GetInvalidTestAuthClient()
        {
            return new TestAuthClient(Guid.NewGuid().ToString(), Guid.NewGuid().ToString());
        }
    }
}
