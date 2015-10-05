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
            int numberForCheck = 65;
            string letterForConvert = "A";
            int expectNumber = Converter.ConvertLettersToNumber(letterForConvert);
            Assert.AreEqual(numberForCheck, expectNumber);
            
        }

        [TestMethod]
        public void TestConvertNumberToLetters()
        {
            string letterForCheck = "a";
            int numberForConvert = 97;
            string expectLetter = Converter.ConvertNumberToLetters(numberForConvert);
            Assert.AreEqual(letterForCheck, expectLetter);

        }

    }
}
