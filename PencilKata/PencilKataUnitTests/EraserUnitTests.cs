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
        private const string testWithEraserDegragation = "This is a t    sentence";
        private const string testSentenceWithWhiteSpace = "This is a      sentence";
        private const string testWord = "test";
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
            // Act
            paper.Text += pencil.Write(testSentence);
            paper.Text = eraser.Erase(testWord, paper.Text);

            // Assert
            Assert.AreEqual(testSentenceWithWhiteSpace, paper.Text, "Test sentence should match paper text, eraser should remove entered word");
        }

        [Test]
        public void TestEraserLosesDurabilityAfterEachUse()
        {
            // Act
            paper.Text += pencil.Write(testSentence);
            paper.Text = eraser.Erase(testWord, paper.Text);

            // Assert
            Assert.AreEqual(eraserDurability - testWord.Length, eraser.Durability, "The erase should lose durability for each letter");
        }

        [Test]
        public void TestEraserDoesNotEraseIfDurabilityIsZero()
        {
            // Arrange
            eraser.Durability = 0;

            // Act
            paper.Text += pencil.Write(testSentence);
            paper.Text = eraser.Erase(testWord, paper.Text);

            // Assert
            Assert.AreEqual(testSentence, paper.Text, "The test sentence and text of paper should match, no erase functionality invoked if zero durability");
        }

        [Test]
        public void TestEraserStopsErasingMidWordIfZeroDurability()
        {
            // Arrange
            eraser.Durability = 3;

            // Act
            paper.Text = pencil.Write(testSentence);
            paper.Text = eraser.Erase(testWord, paper.Text);

            // Assert
            Assert.AreEqual(testWithEraserDegragation, paper.Text, "Text should match the test sentence, eraser should remove text from the right");
        }
    }
}
