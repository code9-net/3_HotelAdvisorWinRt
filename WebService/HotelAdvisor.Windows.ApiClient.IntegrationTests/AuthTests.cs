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
    }
}
