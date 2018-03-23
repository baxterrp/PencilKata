using Domain.Classes;
using NUnit.Framework;

namespace PencilKataUnitTests
{

    [TestFixture]
    public class EraserUnitTests
    {
        private Eraser eraser;
        private Paper paper;
        private Pencil pencil;
        private const string testSentence = "This is a test sentence";
        private const string testSentenceWithWhiteSpace = "This is a      sentence";
        private const int pencilDurability = 50;
        private const int pencilLength = 10;
        private const int eraserDurability = 5;

        [SetUp]
        public void SetupEraserTests()
        {
            pencil = new Pencil(pencilDurability, pencilLength);
            paper = new Paper();
            eraser = new Eraser(eraserDurability);
        }

        [Test]
        public void TestEraserRemovesWordAsEntered()
        {
            // Arrange

            // Act
            paper = pencil.Write(testSentence, paper);
            paper = eraser.Erase("test", paper);

            // Assert
            Assert.AreEqual(testSentenceWithWhiteSpace, paper.Text);
        }

        [Test]
        public void TestEraserLosesDurabilityAfterEachUse()
        {
            // Arrange

            // Act
            paper = pencil.Write(testSentence, paper);
            paper = eraser.Erase("test", paper);

            // Assert
            Assert.AreEqual(eraserDurability - 1, eraser.Durability);
        }

        [Test]
        public void TestEraserDoesNotEraseIfDurabilityIsZero()
        {
            // Arrange

            // Act

            // Assert
        }
    }
}
