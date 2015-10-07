namespace Tests_Common
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GameFifteen.Logic.Common;

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
          "numberForCheck must be a positive integer")]
        public void NegativeIntegerLikeParameterInMehodConvertNumberToLetters()
        {
            const int numberForCheck = -1;
            Converter.ConvertNumberToLetters(numberForCheck);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
          "numberForCheck must be a positive integer")]
        public void ZiroLikeParameterInMehodConvertNumberToLetters()
        {
            const int numberForCheck = 0;
            Converter.ConvertNumberToLetters(numberForCheck);
        }


        [TestMethod]
        public void TestConvertLettersToNumber()
        {
            const int numberForCheck = 1;
            const string letterForConvert = "A";
            int expectNumber = Converter.ConvertLettersToNumber(letterForConvert);
            Assert.AreEqual(numberForCheck, expectNumber);

        }

        [TestMethod]
        public void EmptyStringLikeParametarInMethodConvertLettersToNumber()
        {
            const int numberForCheck = 0;
            const string letterForConvert = "";
            int expectNumber = Converter.ConvertLettersToNumber(letterForConvert);
            Assert.AreEqual(numberForCheck, expectNumber);

        }

        [TestMethod]
        public void StringWithWhiteSpaceLikeParametarInMethodConvertLettersToNumber()
        {
            const int numberForCheck = 1;
            const string letterForConvert = "a ";
            int expectNumber = Converter.ConvertLettersToNumber(letterForConvert);
            Assert.AreEqual(numberForCheck, expectNumber);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
          "letterForConvert must be a positive integer")]
        public void NullLikeParametarInMethodConvertLetterToNumber()
        {
            const string letterForConvert = null;
            Converter.ConvertLettersToNumber(letterForConvert);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
          "letterForConvert must contain only latin letters")]
        public void TestStringContainsOnlyLatinLettersInMethodConvertLetterToNumber()
        {
            const string letterForConvert = "!@##$";
            Converter.ConvertLettersToNumber(letterForConvert);
        }

    }
}
