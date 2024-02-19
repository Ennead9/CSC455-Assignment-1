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

            // Assert
            StringAssert.Matches(result, new System.Text.RegularExpressions.Regex(@"\d{1,2}\/\d{1,2}\/\d{4}"));
        }
        [TestMethod()]
        public void GenerateDinosTest()
        {
            var dinos = Program.CreateDinoList();
            Assert.AreEqual(10, dinos.Count);
        }
        [TestMethod()]
        public void SortDinoListTest()
        {
            // Arrange & Act
            var unsortedDinos = Program.CreateDinoList();
            var sortedDinos = Program.SortDinoList(unsortedDinos);
            var expectedOrder = unsortedDinos.OrderBy(d => d.Name).ToList();
            
            // Assert
            CollectionAssert.AreEqual(expectedOrder, sortedDinos);
        }
        [TestMethod()]
        public void RandomDinoNameTest()
        {
            // Arrange & Act
            var dinos = Program.CreateDinoList();
            var randomIndex = Program.RandomIndex(dinos);
            var name = Program.RandomDinoName(dinos, randomIndex);

            // Assert
            Assert.IsTrue(dinos.Select(d => d.Name).Contains(name));
        }
        [TestMethod()]
        public void RandomStringAction_MakeAllLowercase()
        {
            // Arrange & Act
            var actions = Program.GenerateRandomDinoActions();
            var lowerCaseAction = actions[1];
            var result = lowerCaseAction("DINO NAME");

            // Assert
            Assert.AreEqual("dino name", result);
        }
        [TestMethod()]
        public void RandomStringAction_MakeAllUppercase()
        {
            // Arrange & Act
            var actions = Program.GenerateRandomDinoActions();
            var upperCaseAction = actions[2];
            var result = upperCaseAction("dino name");

            // Assert
            Assert.AreEqual("DINO NAME", result);
        }
        [TestMethod()]
        public void ContainsTest()
        {
            // Arrange & Act
            var actions = Program.GenerateRandomDinoActions();
            var containsAction = actions[3];
            string result = containsAction("Testing");

            // Assert
            Assert.AreEqual(result, "Does not contain the letter 'j'");

        }
        [TestMethod()]
        public void EndsWithTest()
        {
            // Arrange & Act
            var actions = Program.GenerateRandomDinoActions();
            var endsWithAction = actions[4];
            string result = endsWithAction("Testing");

            // Assert
            Assert.AreEqual(result, "You forgot a '.' at the end!");
        }
        [TestMethod()]
        public void LengthTest()
        {
            // Arrange & Act
            var actions = Program.GenerateRandomDinoActions();
            var lengthAction = actions[5];
            string result = lengthAction("Testing");

            // Assert
            Assert.AreEqual(result, "7");
        }
        [TestMethod()]
        public void SumASCIITest()
        {
            // Arrange
            var inputString = "abc"; // Sum = 294?
            var expectedResult = "Sum of ASCII values of input: 294";
            var actions = Program.GenerateRandomDinoActions();
            var sumASCIIAction = actions[8];
            
            // Act
            var result = sumASCIIAction(inputString);

            // Assert
            Assert.AreEqual(expectedResult, result);
        }
    }
}