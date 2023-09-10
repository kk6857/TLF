namespace TransportForLondon.RoadStatusChecker.Tests.Exceptions
{
    using System;
    using TransportForLondon.RoadStatusChecker.Exceptions;
    using Xunit;

    public class ApiExceptionTests
    {
        private ApiException _testClass;
        private string _message;

        public ApiExceptionTests()
        {
            _message = "TestValue1667931944";
            _testClass = new ApiException(_message);
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ApiException(_message);

            // Assert
            Assert.NotNull(instance);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public void CannotConstructWithInvalidMessage(string value)
        {
            Assert.Throws<ArgumentNullException>(() => new ApiException(value));
        }
    }
}