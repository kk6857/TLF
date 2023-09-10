namespace TransportForLondon.RoadStatusChecker.Tests.Helper
{
    using System;
    using TransportForLondon.RoadStatusChecker.Helper;
    using TransportForLondon.RoadStatusChecker.Model;
    using Xunit;

    public class ApiHelperTests
    {
        private ApiHelper _testClass;

        public ApiHelperTests()
        {
            _testClass = new ApiHelper();
        }

        [Fact]
        public void CanCallBuildApiUrl()
        {
            // Arrange
            var apiSettings = new TflApiSettings
            {
                BaseUrl = "BaseUrlTest",
                Endpoint = "EndpointTest",
                AppId = "AppIdTest",
                AppKey = "AppKeyTest"
            };
            var roadId = "roadIdTest";

            // Act
            var result = ApiHelper.BuildApiUrl(apiSettings, roadId);

            // Assert
            Assert.Equal("BaseUrlTest/EndpointTest/roadIdTest?app_id=AppIdTest&app_key=AppKeyTest", result);
        }

        [Fact]
        public void CannotCallBuildApiUrlWithNullApiSettings()
        {
            Assert.Throws<ArgumentNullException>(() => ApiHelper.BuildApiUrl(default(TflApiSettings), "TestValue953470445"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotCallBuildApiUrlWithInvalidRoadId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => ApiHelper.BuildApiUrl(new TflApiSettings
            {
                BaseUrl = "TestValue1272591483",
                Endpoint = "TestValue917667712",
                AppId = "TestValue688761444",
                AppKey = "TestValue140857269"
            }, value));
        }
    }
}