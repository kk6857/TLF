namespace TransportForLondon.RoadStatusChecker.Tests.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using TransportForLondon.RoadStatusChecker.Model;
    using TransportForLondon.RoadStatusChecker.Services;
    using Xunit;

    public class TflApiServiceTests
    {
        private TflApiService _testClass;
        private HttpClient _httpClient;
        private TflApiSettings _apiSettings;

        public TflApiServiceTests()
        {
            _httpClient = new HttpClient();
            _apiSettings = new TflApiSettings
            {
                BaseUrl = "TestValue520972657",
                Endpoint = "TestValue910922838",
                AppId = "TestValue1588756585",
                AppKey = "TestValue1280634761"
            };
            _testClass = new TflApiService(_httpClient, _apiSettings);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new TflApiService(_httpClient, _apiSettings);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullHttpClient()
        {
            Assert.Throws<ArgumentNullException>(() => new TflApiService(default(HttpClient), _apiSettings));
        }

        [Fact]
        public void CannotConstructWithNullApiSettings()
        {
            Assert.Throws<ArgumentNullException>(() => new TflApiService(_httpClient, default(TflApiSettings)));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task CannotCallGetRoadStatusAsyncWithInvalidRoadId(string value)
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.GetRoadStatusAsync(value));
        }
    }
}