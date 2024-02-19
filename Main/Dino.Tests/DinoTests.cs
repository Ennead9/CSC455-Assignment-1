using FluentAssertions;

namespace Dino.Tests
{
    [TestClass]
    public class RandomNumberTests
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
            int result = rnd.Next(min, max);

            // Assert
            result.Should().BeGreaterThanOrEqualTo(min).And.BeLessThanOrEqualTo(max);
        }
    }
}