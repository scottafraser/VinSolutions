using Microsoft.VisualStudio.TestTools.UnitTesting;
using VIN_Solutions;

namespace VIN_Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void FormatWordTest()
        {
            string word = "smooth";
            string expected = "s3h";

            string result = Program.FormatWord(word);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void EndsWithSpecialCharacterTest()
        {
            string word = "hello!";
            bool expected = true;

            bool actual = Program.EndsWithSpecialCharacter(word);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void ParseSentenceTest()
        {
            string input = "hello, this is a sentence!";
            string expected = "h2o, t2s i0s a s4e!";

            string actual = Program.ParseSentence(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
