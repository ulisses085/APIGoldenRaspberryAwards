using APIGoldenRaspberryAwards.Entities;
using APIGoldenRaspberryAwards.Tests.Fixtures;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace APIGoldenRaspberryAwardsFactory.Tests.Scenarios
{
    public class ValuesTest
    {
        private readonly TestContext _testContext;
        public ValuesTest()
        {
            _testContext = new TestContext();
        }

        [Fact]
        public async Task Values_Get_ReturnsGreaterThanZeroResponse()
        {
            var response = await _testContext.Client.GetAsync("/IntervaloPremios");
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();

            var result = JsonSerializer
                .Deserialize<IntervaloPremios>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            Assert.True(result != null && result.Min.Count > 0 && result.Max.Count > 0);
        }
    }
}