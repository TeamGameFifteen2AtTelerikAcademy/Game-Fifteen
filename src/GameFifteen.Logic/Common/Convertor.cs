// <copyright file="Converter.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for ICommandManager.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Common
{
    using System;

    /// <summary>
    /// This static class converts numbers to letters and letters to numbers.
    /// </summary>
    public static class Converter
    {
        /// <summary>
        /// Converts a number to letters representation.<br/>
        /// 1 -> a<br/>
        /// 2 -> b<br/>
        /// ...<br/>
        /// 27 -> з.
        /// </summary>
        /// <param name="number">Number that will be convert.</param>
        /// <returns>Letter string.</returns>
        public static string ConvertNumberToLetters(int number)
        {
            Validator.ValidateIsPositiveInteger(number, "number");

            string letters = string.Empty;
            while (number > 0)
            {
                int currentLetterNumber = (number - 1) % Constants.EnglishAlphabetLettersCount;
                char currentLetter = (char)(currentLetterNumber + 'a');
                letters = currentLetter + letters;
                number = (number - (currentLetterNumber + 1)) / Constants.EnglishAlphabetLettersCount;
            }

            return letters;
        }

        /// <summary>
        /// Converts letters to a number.<br/>
        /// a -> 1<br/>
        /// b -> 2<br/>
        /// ...
        /// z -> 27.
        /// </summary>
        /// <param name="letters">Letter that will be convert.</param>
        /// <returns>Number string.</returns>
        public static int ConvertLettersToNumber(string letters)
        {
            Validator.ValidateIsNotNull(letters, "letters");
            letters = letters.Trim();
            Validator.ValidateStringContainsOnlyLatinLetters(letters);
            int number = 0;
            string lowerLetters = letters.ToLower();
            
            for (int lowerLetterIndex = lowerLetters.Length - 1; lowerLetterIndex >= 0; lowerLetterIndex--)
            {
                char lowerLetter = lowerLetters[lowerLetterIndex];
                int letterNumber = lowerLetter - 'a' + 1;
                number += letterNumber * (int)Math.Pow(
                    Constants.EnglishAlphabetLettersCount, lowerLetters.Length - (lowerLetterIndex + 1));
            }

            return number;
        }
    }
}
