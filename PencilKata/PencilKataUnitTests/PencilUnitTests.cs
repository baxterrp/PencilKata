using Domain.Classes;
using NUnit.Framework;
using System.Linq;

namespace PencilKataUnitTests
{
    public class PencilTests
    {
        private Pencil pencil;
        private Paper paper;
        private const string genericTestSentence = "This is a test sentence";
        private const string testSentenceWithSpace = "This is a      sentence";
        private const string testSentenceWithSpecialCharacters = "This is a rober@entence";
        private const int pencilDurability = 50;
        private const int pencilLength = 10;

        [SetUp]
        public void SetupPencilTests()
        {
            pencil = new Pencil(pencilDurability, pencilLength);
            paper = new Paper();
        }

        [Test]
        public void TestPencilWritesToPaper()
        {
            // Arrange

            // Act
            paper = pencil.Write(genericTestSentence, paper);

            // Assert
            Assert.AreEqual(genericTestSentence, paper.Text, "The text of the paper should match the constant testSentence");
        }

        [Test]
        public void TestPencilWritesSpacesIfDurabilityIsZero()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public void TestPencilWritesSpecialCharacterIfNoFreeWhiteSpace()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public void TestPencilLosesDurabilityAfterUse()
        {
            // Arrange
            int decrementedDurability = pencilDurability - genericTestSentence.Count(char.IsLetter);

            // Act
            pencil.Write(genericTestSentence, paper);

            // Assert
            Assert.AreEqual(decrementedDurability, pencil.CurrentDurability, "Current durability should be one less than original durability");
        }

        [Test]
        public void TestPencilRegainsDurabilityAfterSharpening()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public void TestPencilLosesLengthAfterSharpening()
        {
            // Arrange

            // Act

            // Assert
        }

        [Test]
        public void TestEditAddsToFirstBlankSpaceOnPaper()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
