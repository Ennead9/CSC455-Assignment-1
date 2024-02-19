using FluentAssertions;

namespace CSC455_Assignment_1.Tests
{
    [TestClass]
    public class DinoTests
    {
        [DataTestMethod]
        [DataRow(1, 11)]
        [DataRow(2, 6)]
        [DataRow(34, 45)]
        [TestMethod]
        public void GenerateRandomIntTest(int min, int max)
        {
            // Arrange
            var rnd = new Random();

            // Act
            int result = Program.GenerateRandomInt(min, max);

            // Assert
            result.Should().BeGreaterThanOrEqualTo(min).And.BeLessThanOrEqualTo(max);
        }
        [DataTestMethod]
        [DataRow(1996, 3, 20)]
        [DataRow(2008, 5, 29)]
        [DataRow(2023, 2, 17)]
        [DataRow(2017, 7, 14)]
        public void ConvertDateToStringTest(int year, int month, int day)
        {
            // Arrange
            var date = new DateTime(year, month, day);
            var expected = date.ToShortDateString();

            // Act
            var result = Program.ConvertDateToString(date);
        }
    }
}