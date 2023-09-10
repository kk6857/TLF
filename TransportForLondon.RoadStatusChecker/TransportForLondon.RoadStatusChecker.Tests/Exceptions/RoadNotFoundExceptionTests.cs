namespace TransportForLondon.RoadStatusChecker.Tests.Exceptions
{
    using System;
    using TransportForLondon.RoadStatusChecker.Exceptions;
    using Xunit;

    public class RoadNotFoundExceptionTests
    {
        private RoadNotFoundException _testClass;
        private string _roadId;

        public RoadNotFoundExceptionTests()
        {
            _roadId = "TestValue2046588812";
            _testClass = new RoadNotFoundException(_roadId);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new RoadNotFoundException(_roadId);

            // Assert
            Assert.NotNull(instance);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidRoadId(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new RoadNotFoundException(value));
        }

        [Fact]
        public void RoadIdIsInitializedCorrectly()
        {
            Assert.Equal(_roadId, _testClass.RoadId);
        }
    }
}