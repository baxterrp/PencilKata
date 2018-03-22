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
        private const string testSentenceDullPencil = "This is a test sent    ";
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
            pencil.CurrentDurability = 15;

            // Act
            paper = pencil.Write(genericTestSentence, paper);

            // Assert
            Assert.AreEqual(testSentenceDullPencil, paper.Text);
        }

        [Test]
        public void TestPencilLosesDurabilityAfterUse()
        {
            // Arrange
            int decrementedDurability = pencilDurability - genericTestSentence.Count(character => character != ' ');

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
            pencil.Write(genericTestSentence, paper);
            pencil.Sharpen();

            // Assert
            Assert.AreEqual(pencil.MaxDurability, pencil.CurrentDurability);
        }

        [Test]
        public void TestPencilLosesLengthAfterSharpening()
        {
            // Arrange

            // Act
            pencil.Sharpen();

            // Assert
            Assert.AreEqual(pencilLength - 1, pencil.Length);
        }

        [Test]
        public void TestEditAddsToFirstBlankSpaceOnPaper()
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
    }
}
