namespace TransportForLondon.RoadStatusChecker.Tests.Model
{
    using System;
    using TransportForLondon.RoadStatusChecker.Model;
    using Xunit;

    public class RoadStatusTests
    {
        private RoadStatus _testClass;

        public RoadStatusTests()
        {
            _testClass = new RoadStatus();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var testValue = "TestValue98178017";

            // Act
            _testClass.Id = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.Id);
        }

        [Fact]
        public void CanSetAndGetDisplayName()
        {
            // Arrange
            var testValue = "TestValue450398968";

            // Act
            _testClass.DisplayName = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.DisplayName);
        }

        [Fact]
        public void CanSetAndGetStatusSeverity()
        {
            // Arrange
            var testValue = "TestValue458674370";

            // Act
            _testClass.StatusSeverity = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.StatusSeverity);
        }

        [Fact]
        public void CanSetAndGetStatusSeverityDescription()
        {
            // Arrange
            var testValue = "TestValue1880544951";

            // Act
            _testClass.StatusSeverityDescription = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.StatusSeverityDescription);
        }
    }
}