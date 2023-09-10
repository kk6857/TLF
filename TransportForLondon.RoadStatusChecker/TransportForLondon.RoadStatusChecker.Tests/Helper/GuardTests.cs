namespace TransportForLondon.RoadStatusChecker.Tests.Helper
{
    using System;
    using TransportForLondon.RoadStatusChecker.Helper;
    using Xunit;

    public static class GuardTests
    {
        [Fact]
        public static void CanCallAgainstNullOrWhiteSpace()
        {
            // Arrange
            var value = "TestValue1131039630";
            var argName = "value";

            //Act
            var exception = Record.Exception(() => Guard.AgainstNullOrWhiteSpace(value, argName));

            //Assert
            Assert.Null(exception);

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public static void CannotCallAgainstNullOrWhiteSpaceWithInvalidValue(string value)
        {
            Assert.Throws<ArgumentNullException>(() => Guard.AgainstNullOrWhiteSpace(value, "TestValue315350716"));
        }

        [Fact]
        public static void CanCallAgainstNull()
        {
            // Arrange
            var value = new object();
            var argName = "TestValue1872136943";

            //Act
            var exception = Record.Exception(() => Guard.AgainstNull(value, argName));

            //Assert
            Assert.Null(exception);
        }

        [Fact]
        public static void CannotCallAgainstNullWithNullValue()
        {
            Assert.Throws<ArgumentNullException>(() => Guard.AgainstNull(default(object), "TestValue1051385018"));
        }
    }
}