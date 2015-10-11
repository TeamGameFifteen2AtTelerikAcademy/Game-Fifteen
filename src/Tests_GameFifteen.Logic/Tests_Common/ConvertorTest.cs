namespace Tests_Common
{
    using System;
    using GameFifteen.Logic.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for ConvertorTest
    /// </summary>
    [TestClass]
    public class ConvertorTest
    {
        [TestMethod]
        public void TestConvertNumberToLetters()
        {
            string letterForCheck = "cs";
            int numberForConvert = 97;
            string expectLetter = Converter.ConvertNumberToLetters(numberForConvert);
            Assert.AreEqual(letterForCheck, expectLetter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
          "NumberForCheck must be a positive integer")]
        public void NegativeIntegerLikeParameterInMehodConvertNumberToLetters()
        {
            const int NumberForCheck = -1;
            Converter.ConvertNumberToLetters(NumberForCheck);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
          "NumberForCheck must be a positive integer")]
        public void ZiroLikeParameterInMehodConvertNumberToLetters()
        {
            const int NumberForCheck = 0;
            Converter.ConvertNumberToLetters(NumberForCheck);
        }

        [TestMethod]
        public void TestConvertLettersToNumber()
        {
            const int NumberForCheck = 1;
            const string LetterForConvert = "A";
            int expectNumber = Converter.ConvertLettersToNumber(LetterForConvert);
            Assert.AreEqual(NumberForCheck, expectNumber);
        }

        [TestMethod]
        public void EmptyStringLikeParametarInMethodConvertLettersToNumber()
        {
            const int NumberForCheck = 0;
            const string LetterForConvert = "";
            int expectNumber = Converter.ConvertLettersToNumber(LetterForConvert);
            Assert.AreEqual(NumberForCheck, expectNumber);
        }

        [TestMethod]
        public void StringWithWhiteSpaceLikeParametarInMethodConvertLettersToNumber()
        {
            const int NumberForCheck = 1;
            const string LetterForConvert = "a ";
            int expectNumber = Converter.ConvertLettersToNumber(LetterForConvert);
            Assert.AreEqual(NumberForCheck, expectNumber);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
          "LetterForConvert must be a positive integer")]
        public void NullLikeParametarInMethodConvertLetterToNumber()
        {
            const string LetterForConvert = null;
            Converter.ConvertLettersToNumber(LetterForConvert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
          "LetterForConvert must contain only latin letters")]
        public void TestStringContainsOnlyLatinLettersInMethodConvertLetterToNumber()
        {
            const string LetterForConvert = "!@##$";
            Converter.ConvertLettersToNumber(LetterForConvert);
        }
    }
}
