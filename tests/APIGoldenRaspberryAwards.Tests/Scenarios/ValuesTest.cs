using APIGoldenRaspberryAwards.Tests.IntegrationTests;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace APIGoldenRaspberryAwardsFactory.Tests.IntegrationTests
{
    public class ValuesTest
    {
        private readonly TestContext _testContext;
        public ValuesTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Values_Get_ReturnsOkResponse()
        {
            var response = await _testContext.Client.GetAsync("/IntervaloPremios");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}