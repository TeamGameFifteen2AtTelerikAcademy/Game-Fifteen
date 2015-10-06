using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen.Logic.Common;

namespace Tests_Common
{
    /// <summary>
    /// Summary description for ConvertorTest
    /// </summary>
    [TestClass]
    public class ConvertorTest
    {
        [TestMethod]
        public void TestConvertLettersToNumber()
        {
            const int numberForCheck = 1;
            const string letterForConvert = "A";
            int expectNumber = Converter.ConvertLettersToNumber(letterForConvert);
            Assert.AreEqual(numberForCheck, expectNumber);
            
        }

        
        [TestMethod]
        public void TestConvertNumberToLetters()
        {
            string letterForCheck = "cs";
            int numberForConvert = 97;
            string expectLetter = Converter.ConvertNumberToLetters(numberForConvert);
            Assert.AreEqual(letterForCheck, expectLetter);

        }

        [TestMethod]
        public void EmptyStringLikeParametarInMethodConvertNumberToLetters()
        {
            const int numberForCheck = 0;
            const string letterForConvert = "";
            int expectNumber = Converter.ConvertLettersToNumber(letterForConvert);
            Assert.AreEqual(numberForCheck, expectNumber);

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


    }
}
