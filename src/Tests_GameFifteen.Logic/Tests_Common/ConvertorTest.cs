// <copyright file="ConvertorTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ConvertorTest class.
// </summary>
// <author>GameFifteen2Team</author>

namespace Tests_Common
{
    using System;
    using GameFifteen.Logic.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    
    /// <summary>
    /// The tests for Converter class.
    /// </summary>
    [TestClass]
    public class ConvertorTest
    {
        /// <summary>
        /// The method tests converting number to letter.
        /// </summary>
        [TestMethod]
        public void TestConvertNumberToLetters()
        {
            string letterForCheck = "cs";
            int numberForConvert = 97;
            string expectLetter = Converter.ConvertNumberToLetters(numberForConvert);
            Assert.AreEqual(letterForCheck, expectLetter);
        }

        /// <summary>
        /// The method tests if exception is thrown when negative number is provided converting.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
          "NumberForCheck must be a positive integer")]
        public void NegativeIntegerLikeParameterInMehodConvertNumberToLetters()
        {
            const int NumberForCheck = -1;
            Converter.ConvertNumberToLetters(NumberForCheck);
        }

        /// <summary>
        /// The method tests if exception is thrown when 0 number is provided converting.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
          "NumberForCheck must be a positive integer")]
        public void ZiroLikeParameterInMehodConvertNumberToLetters()
        {
            const int NumberForCheck = 0;
            Converter.ConvertNumberToLetters(NumberForCheck);
        }

        /// <summary>
        /// The method tests converting letter to number.
        /// </summary>
        [TestMethod]
        public void TestConvertLettersToNumber()
        {
            const int NumberForCheck = 1;
            const string LetterForConvert = "A";
            int expectNumber = Converter.ConvertLettersToNumber(LetterForConvert);
            Assert.AreEqual(NumberForCheck, expectNumber);
        }

        /// <summary>
        /// The method if empty string returns 0.
        /// </summary>
        [TestMethod]
        public void EmptyStringLikeParametarInMethodConvertLettersToNumber()
        {
            const int NumberForCheck = 0;
            const string LetterForConvert = "";
            int expectNumber = Converter.ConvertLettersToNumber(LetterForConvert);
            Assert.AreEqual(NumberForCheck, expectNumber);
        }

        /// <summary>
        /// The method tests converting letter to number with empty space string provided.
        /// </summary>
        [TestMethod]
        public void StringWithWhiteSpaceLikeParametarInMethodConvertLettersToNumber()
        {
            const int NumberForCheck = 1;
            const string LetterForConvert = "a ";
            int expectNumber = Converter.ConvertLettersToNumber(LetterForConvert);
            Assert.AreEqual(NumberForCheck, expectNumber);
        }

        /// <summary>
        /// The method tests if exception is thrown when null letter is provided.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
          "LetterForConvert must be a positive integer")]
        public void NullLikeParametarInMethodConvertLetterToNumber()
        {
            const string LetterForConvert = null;
            Converter.ConvertLettersToNumber(LetterForConvert);
        }

        /// <summary>
        /// The method tests if exception is thrown when no letter strings are provided.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
          "LetterForConvert must contain only Latin letters")]
        public void TestStringContainsOnlyLatinLettersInMethodConvertLetterToNumber()
        {
            const string LetterForConvert = "!@##$";
            Converter.ConvertLettersToNumber(LetterForConvert);
        }
    }
}
