namespace TransportForLondon.RoadStatusChecker.Tests
{
    using System;
    using System.Threading.Tasks;
    using NSubstitute;
    using NSubstitute.ExceptionExtensions;
    using TransportForLondon.RoadStatusChecker;
    using TransportForLondon.RoadStatusChecker.Exceptions;
    using TransportForLondon.RoadStatusChecker.Model;
    using TransportForLondon.RoadStatusChecker.Services;
    using Xunit;

    public class RoadInfoProvider
    {
        private RoadStatusChecker.RoadInfoProvider _testClass;
        private ITflApiService _apiService;

        public RoadInfoProvider()
        {
            _apiService = Substitute.For<ITflApiService>();
            _testClass = new RoadStatusChecker.RoadInfoProvider(_apiService);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new RoadStatusChecker.RoadInfoProvider(_apiService);

            // Assert
            Assert.NotNull(instance);
        }

        [Fact]
        public void CannotConstructWithNullApiService()
        {
            Assert.Throws<ArgumentNullException>(() => new RoadStatusChecker.RoadInfoProvider(default(ITflApiService)));
        }

        [Fact]
        public async Task CannotCallRunAsyncWithNullArgs()
        {
            await Assert.ThrowsAsync<ArgumentNullException>(() => _testClass.RunAsync(default(string[])));
        }

        [Fact]
        public async Task RunAsyncValidRoadIdReturnsZero()
        {
            // Arrange
            string[] args = { "A2" };
            string expectedDisplayName = "A2";

            var mockApiService = Substitute.For<ITflApiService>();
            mockApiService.GetRoadStatusAsync(Arg.Any<string>())
                .Returns(new RoadStatusChecker.Model.RoadStatus
                {
                    DisplayName = expectedDisplayName,
                    StatusSeverity = "Good",
                    StatusSeverityDescription = "No Exceptional Delay"
                });

            var roadStatusChecker = new RoadStatusChecker.RoadInfoProvider(mockApiService);

            // Act
            int result = await roadStatusChecker.RunAsync(args);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public async Task RunAsyncNonExistentRoadIdReturnsOne()
        {
            // Arrange
            string[] args = { "A233" };
            string expectedDisplayName = "A233";

            var mockApiService = Substitute.For<ITflApiService>();
            mockApiService.GetRoadStatusAsync(Arg.Any<string>())
                .Returns(new RoadStatusChecker.Model.RoadStatus
                {
                    DisplayName = expectedDisplayName,
                    StatusSeverity = "Good",
                    StatusSeverityDescription = "No Exceptional Delay"
                });

            var roadStatusChecker = new RoadStatusChecker.RoadInfoProvider(mockApiService);

            // Act
            int result = await roadStatusChecker.RunAsync(args);

            // Assert
            Assert.Equal(0, result);
        }

        [Fact]
        public async Task RunAsyncRoadNotFoundExceptionReturnsOne()
        {
            // Arrange
            string[] args = { "InvalidRoadId" };
            string roadId = "InvalidRoadId";

            var mockApiService = Substitute.For<ITflApiService>();
            mockApiService.GetRoadStatusAsync("InvalidRoadId")
                .Throws(new RoadNotFoundException(roadId));

            var roadStatusChecker = new RoadStatusChecker.RoadInfoProvider(mockApiService);

            // Act
            int result = await roadStatusChecker.RunAsync(args);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task RunAsyncApiExceptionReturnsOne()
        {
            // Arrange
            string[] args = { "A2" };

            var mockApiService = Substitute.For<ITflApiService>();
            mockApiService.GetRoadStatusAsync("A2")
                .Throws(new ApiException("API Error"));

            var roadStatusChecker = new RoadStatusChecker.RoadInfoProvider(mockApiService);

            // Act
            int result = await roadStatusChecker.RunAsync(args);

            // Assert
            Assert.Equal(1, result);
        }

        [Fact]
        public async Task RunAsyncInvalidRoadIdReturnsOne()
        {
            // Arrange
            string[] args = { };

            var mockApiService = Substitute.For<ITflApiService>();
            var roadStatusChecker = new RoadStatusChecker.RoadInfoProvider(mockApiService);

            // Act
            int result = await roadStatusChecker.RunAsync(args);

            // Assert
            Assert.Equal(1, result);
        }


    }
}