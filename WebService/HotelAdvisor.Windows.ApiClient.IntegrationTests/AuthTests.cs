using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace HotelAdvisor.Windows.ApiClient.IntegrationTests
{
    [TestClass]
    public class AuthTests
    {
        [TestMethod]
        public async Task TestAuthNoAuth()
        {
            var client = ClientResolver.GetTestAuthClient();
            await client.TestAuthNoAuth();
        }

        [TestMethod]
        public async Task TestAuthWithValidUser()
        {
            var client = ClientResolver.GetTestAuthClient();
            bool result = await client.TestAuthWithAuth();
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task TestAuthWithInvalidUser()
        {
            var client = ClientResolver.GetInvalidTestAuthClient();
            bool result = await client.TestAuthWithAuth();
            Assert.IsFalse(result);
        }

        [TestMethod]
        public async Task TestGetAutnWithValidUser()
        {
            var client = ClientResolver.GetTestAuthClient();
            await client.TestGetAuth();
        }

        [TestMethod]
        public async Task TestGetAutnWithInvalidUser()
        {
            bool error = false;
            try
            {
                var client = ClientResolver.GetInvalidTestAuthClient();
                await client.TestGetAuth();
            }
            catch (UnauthorizedAccessException)
            {
                error = true;
            }
            Assert.IsTrue(error);
        }

        [TestMethod]
        public async Task TestRegisteredUser()
        {
            string username = "test@test.com";
            string password = "Password.1";
            var client = new AuthClient(username, password);
            bool loginResult = await client.Login();
            Assert.IsTrue(loginResult);
        }

        [TestMethod]
        public async Task TestNotRegisteredUser()
        {
            string username = Guid.NewGuid().ToString("N");
            string password = Guid.NewGuid().ToString("N");
            var client = new AuthClient(username, password);
            bool loginResult = await client.Login();
            Assert.IsFalse(loginResult);
        }
    }
}
