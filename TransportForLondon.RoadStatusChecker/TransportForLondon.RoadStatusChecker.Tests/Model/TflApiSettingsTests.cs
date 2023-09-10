namespace TransportForLondon.RoadStatusChecker.Tests.Model
{
    using System;
    using TransportForLondon.RoadStatusChecker.Model;
    using Xunit;

    public class TflApiSettingsTests
    {
        private TflApiSettings _testClass;

        public TflApiSettingsTests()
        {
            _testClass = new TflApiSettings();
        }

        [Fact]
        public void CanSetAndGetBaseUrl()
        {
            // Arrange
            var testValue = "TestValue685142775";

            // Act
            _testClass.BaseUrl = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.BaseUrl);
        }

        [Fact]
        public void CanSetAndGetEndpoint()
        {
            // Arrange
            var testValue = "TestValue1161151440";

            // Act
            _testClass.Endpoint = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Endpoint);
        }

        [Fact]
        public void CanSetAndGetAppId()
        {
            // Arrange
            var testValue = "TestValue2011358049";

            // Act
            _testClass.AppId = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AppId);
        }

        [Fact]
        public void CanSetAndGetAppKey()
        {
            // Arrange
            var testValue = "TestValue1506123996";

            // Act
            _testClass.AppKey = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.AppKey);
        }
    }
}