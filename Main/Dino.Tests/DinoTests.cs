

namespace Dino.Tests
{
    [TestClass]
    public class RandomNumberTests
    {
        [TestMethod]
        public void GenerateRandomIntTest()
        {
            // Arrange
            int min = 1;
            int max = 11;
            var rnd = new Random();

            // Act
            int result = rnd.Next(min, max);

            // Assert
            result.Should().Be(min);
        }
    }
}