using System;
using System.Threading.Tasks;

namespace HotelAdvisor.Windows.ApiClient
{
    public class TestAuthClient : ApiClientBase
    {
        private readonly string _baseUrl = Config.ApiBaseUrl + "AuthTest/";

        public TestAuthClient(string username, string password) : base(username, password)
        {

        }

        public async Task TestAuthNoAuth()
        {
            string url = _baseUrl + "TestAuthNoAuth";
            await PostToBool(url, null);
        }

        public async Task<bool> TestAuthWithAuth()
        {
            string url = _baseUrl + "TestAuthWithAuth";
            return await PostToBool(url, null);
        }

        public async Task TestGetAuth()
        {
            string url = _baseUrl + "TestAuthGet";
            await GetData<dynamic>(url, null);
        }
    }
}
