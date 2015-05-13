using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;

namespace HotelAdvisor.Windows.ApiClient.IntegrationTests
{
    [TestClass]
    public class HotelClientTests
    {
        [TestMethod]
        public async Task GetAll()
        {
            var models = await ClientResolver.GetHotelClient().GetAll();
            Assert.IsTrue(models.Any());
        }

    }
}
