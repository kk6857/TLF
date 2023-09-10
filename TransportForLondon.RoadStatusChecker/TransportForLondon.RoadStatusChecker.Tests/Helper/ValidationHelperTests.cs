namespace TransportForLondon.RoadStatusChecker.Tests.Helper
{
    using Microsoft.VisualStudio.TestPlatform.ObjectModel;
    using System;
    using System.ComponentModel.DataAnnotations;
    using TransportForLondon.RoadStatusChecker.Helper;
    using Xunit;
    using T = System.String;

    public class ValidationHelperTests
    {
        private ValidationHelper _testClass;

        public ValidationHelperTests()
        {
            _testClass = new ValidationHelper();
        }

        [Fact]
        public void ValidateObjectReturnsTrue()
        {
            // Arrange
            var validObject = new TestModel { TestProperty = "TestValue" };

            // Act
            var isValid = ValidationHelper.ValidateObject(validObject);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void ValidateObjectReturnsFalse()
        {
            // Arrange
            var validObject = new TestModel { TestProperty = null };

            // Act
            var isValid = ValidationHelper.ValidateObject(validObject);

            // Assert
            Assert.False(isValid);
        }

        private class TestModel 
        {
            [Required] 
            public string TestProperty { get; set; }
        }
    }
}