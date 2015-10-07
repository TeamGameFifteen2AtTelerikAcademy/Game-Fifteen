namespace GameFifteen.Logic.Common
{
    using System;

    public static class Converter
    {
        /// <summary>
        /// Converts a number to letters representation.<br/>
        /// 1 -> a<br/>
        /// 2 -> b<br/>
        /// ...<br/>
        /// 27 -> aa
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
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
        /// aa -> 27
        /// </summary>
        /// <param name="letters"></param>
        /// <returns></returns>
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
