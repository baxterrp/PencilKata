﻿using Domain.Classes;
using NUnit.Framework;

namespace PencilKataUnitTests
{
    public class PencilTests
    {
        private Pencil pencil;
        private Paper paper;
        private const string genericTestSentence = "This is a test sentence";
        private const string testSentenceConcatenated = " and this is a second sentence";
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
            // Act
            paper.Text += pencil.Write(genericTestSentence);

            // Assert
            Assert.AreEqual(genericTestSentence, paper.Text, "The text of the paper should match the constant testSentence");
        }

        [Test]
        public void TestPencilWriteAllowsConcatenation()
        {
            // Act
            paper.Text += pencil.Write(genericTestSentence);
            paper.Text += pencil.Write(testSentenceConcatenated);

            // Assert
            Assert.AreEqual(genericTestSentence + testSentenceConcatenated, paper.Text, "The text of the paper should match the constant testSentence + testSentenceConcatenated");
        }

        [Test]
        public void TestPencilLosesDurabilityAfterUse()
        {
            // Arrange
            // point loss for 29 letters 1 uppercase letter
            int decrementedDurability = 30;

            // Act
            pencil.Write(genericTestSentence);

            // Assert
            Assert.AreEqual(decrementedDurability, pencil.CurrentDurability, "Current durability should be one less than original durability");
        }

        [Test]
        public void TestPencilWritesSpacesIfDurabilityIsZero()
        {
            // Arrange
            // Durabilty accounting for 1 upper case letter
            pencil.CurrentDurability = 16;

            // Act
            paper.Text = pencil.Write(genericTestSentence);

            // Assert
            Assert.AreEqual(testSentenceDullPencil, paper.Text, "test sentence should match paper text, no letters shown if pencil durability is zero");
        }

        [Test]
        public void TestPencilRegainsDurabilityAfterSharpening()
        {
            // Act
            pencil.Write(genericTestSentence);
            pencil.Sharpen();

            // Assert
            Assert.AreEqual(pencil.MaxDurability, pencil.CurrentDurability, "Pencil durability should match max durability after sharpened");
        }

        [Test]
        public void TestPencilLosesLengthAfterSharpening()
        {
            // Act
            pencil.Sharpen();

            // Assert
            Assert.AreEqual(pencilLength - 1, pencil.Length, "The pencil should lose 1 durabilty after each sharpening");
        }

        [Test]
        public void TestEditAddsToFirstBlankSpaceOnPaper()
        {
            // Act
            paper.Text += pencil.Write(testSentenceWithSpace);
            paper.Text = pencil.Edit("test", paper.Text);

            // Assert
            Assert.AreEqual(genericTestSentence, paper.Text, "Test sentence should match paper text, edit should add word to first blank area in sentence");
        }

        [Test]
        public void TestEditDegragradesPencil()
        {
            // Arrange
            paper.Text += pencil.Write(testSentenceWithSpace);
            int expectedDurability = pencil.CurrentDurability - 4;

            // Act
            paper.Text = pencil.Edit("test", paper.Text);

            // Assert
            Assert.AreEqual(pencil.CurrentDurability, expectedDurability, "The pencil should lose 4 durabilty, 1 for each character in 'test'");

            // Assert

        }

        [Test]
        public void TestPencilWritesSpecialCharacterIfNoFreeWhiteSpace()
        {
            // Act
            paper.Text += pencil.Write(testSentenceWithSpace);
            paper.Text = pencil.Edit("robert", paper.Text);

            // Assert
            Assert.AreEqual(testSentenceWithSpecialCharacters, paper.Text, 
                "Test sentence should match paper text, @ symbol should replace any non-whitespace characters if word overlaps existing characters");
        }
    }
}
