using NUnit.Framework;
using Doppel;
using System;
using System.Collections.Generic;

namespace Doppel.Tests
{
    [TestFixture]
    class TextParserTests
    {
        readonly TextParser Parser = new TextParser();

        readonly string NoPunctuation = "This has no punctuation";
        readonly string SomePunctuation = "This has 'some' punctuation.";
        readonly string AllPunctuation = ".,\"'!?%&*()[]-–_;:@#";

        readonly string NoLineEndings = "This has no line endings";
        readonly string SomeLineEndings = "\nThis has some line endings\r\n";
        readonly string AllLineEndings = "\n\n\n\n\r\n\r\n\r\n\n";

        readonly string FullTestString = "This 'test' incorporates every test!\r\n";

        #region RemovePunctuation tests

        [Test]
        public void RemovePunctuationWithNoPunctuation()
        {
            string actual = Parser.RemovePunctuation(NoPunctuation);
            Assert.AreEqual(NoPunctuation, actual);
        }

        [Test]
        public void RemovePunctuationWithSomePunctuation()
        {
            string actual = Parser.RemovePunctuation(SomePunctuation);
            Assert.AreEqual("This has some punctuation", actual);
        }

        [Test]
        public void RemovePunctuationWithAllPunctuation()
        {
            string actual = Parser.RemovePunctuation(AllPunctuation);
            Assert.AreEqual(string.Empty, actual);
        }

        #endregion

        #region RemoveLineEndings tests

        [Test]
        public void RemoveLineEndingsWithNoLineEndings()
        {
            string actual = Parser.RemoveLineEndings(NoLineEndings);
            Assert.AreEqual(NoLineEndings, actual);
        }

        [Test]
        public void RemoveLineEndingsWithSomeLineEndings()
        {
            string actual = Parser.RemoveLineEndings(SomeLineEndings);
            Assert.AreEqual("This has some line endings", actual);
        }

        [Test]
        public void RemoveLineEndingsWithAllLineEndings()
        {
            string actual = Parser.RemoveLineEndings(AllLineEndings);
            Assert.AreEqual(string.Empty, actual);
        }

        #endregion

        #region StandardizeText tests

        [Test]
        public void StandardizeTextWithPunctuation()
        {
            string actual = Parser.StandardizeText(AllPunctuation);
            Assert.AreEqual(string.Empty, actual);
        }

        [Test]
        public void StandardizeTextWithLineEndings()
        {
            string actual = Parser.StandardizeText(SomeLineEndings);
            Assert.AreEqual("this has some line endings", actual);
        }

        [Test]
        public void StandardizeTextWithFullTestString()
        {
            string actual = Parser.StandardizeText(FullTestString);
            Assert.AreEqual("this test incorporates every test", actual);
        }

        #endregion

        #region CountWords tests

        [Test]
        public void CountWordsWithNoWords()
        {
            IDictionary<string, int> actual = Parser.CountWords(AllPunctuation);
            var expected = new Dictionary<string, int>();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CountWordsWithFullTestString()
        {
            IDictionary<string, int> actual = Parser.CountWords(FullTestString);
            var expected = new Dictionary<string, int>
            {
                {"this", 1 },
                {"test", 2 },
                {"incorporates", 1 },
                {"every", 1 }
            };
            Assert.AreEqual(expected, actual);
        }

        #endregion
    }
}
