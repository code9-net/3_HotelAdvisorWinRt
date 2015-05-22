using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAdvisorWinRTClientApp.Services
{
    public static class WebClients
    {
        private static string _username;
        private static string _password;
        private static bool _isSet;

        public static void SetUsernameAndPassword(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Empty argument provided.", "username");
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException("Empty argument provided.", "password");
            }
            _isSet = true;
            _username = username;
            _password = password;
        }

        public static HotelAdvisor.Windows.ApiClient.CommentsClient CommentsClient
        {
            get
            {
                return new HotelAdvisor.Windows.ApiClient.CommentsClient(_username, _username);
            }
        }

        public static HotelAdvisor.Windows.ApiClient.HotelClient HotelClient
        {
            get
            {
                return new HotelAdvisor.Windows.ApiClient.HotelClient(_username, _username);
            }
        }
    }
}
