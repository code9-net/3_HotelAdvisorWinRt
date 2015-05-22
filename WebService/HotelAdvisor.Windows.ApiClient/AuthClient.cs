using HotelAdvisor.Windows.ApiModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelAdvisor.Windows.ApiClient
{
    public class AuthClient : ApiClientBase
    {
        private readonly RegisterModel _userData;

        private readonly string _baseUrl = Config.ApiBaseUrl + "Auth/";

        public AuthClient(string username, string password) : base(username, password) 
        {
            _userData = new RegisterModel
            {
                Username = username,
                Password = password
            };
        }

        public async Task<bool> Login()
        {
            string url = _baseUrl + "Validate";
            return await GetToBool(url, _userData);
        }

        public async Task<bool> Register()
        {
            string url = _baseUrl + "Register";
            return await PostToBool(url, _userData);
        }
    }
}
