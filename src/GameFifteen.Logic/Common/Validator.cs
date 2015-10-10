// <copyright file="Validator.cs" company="GameFifteen2Team">
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
    using System.Text.RegularExpressions;

    /// <summary>
    /// This static class is validate different cases and throws appropriate exceptions.
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// Validate argument is not null.
        /// </summary>
        /// <param name="argument">Argument that will be validate.</param>
        /// <param name="argumentName">Argument name.</param>
        public static void ValidateIsNotNull(object argument, string argumentName = Constants.ArgumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, string.Format(Constants.CannotBeNullFormat, argumentName));
            }
        }

        /// <summary>
        /// Validate string is only Latin letters.
        /// </summary>
        /// <param name="argument">Argument that will be validate.</param>
        /// <param name="argumentName">Argument name.</param>
        public static void ValidateStringContainsOnlyLatinLetters(string argument, string argumentName = Constants.ArgumentName)
        {
            if (!Regex.IsMatch(argument, @"^[a-zA-Z]*$"))
            {
                throw new ArgumentException(argumentName, string.Format(Constants.StringContainsOnlyLatinLetters, argumentName));
            }
        }

        /// <summary>
        /// Validate argument is positive integer.
        /// </summary>
        /// <param name="argument">Argument that will be validate.</param>
        /// <param name="paramName">Argument name.</param>
        public static void ValidateIsPositiveInteger(int argument, string paramName)
        {
            if (argument <= 0)
            {
                throw new ArgumentOutOfRangeException(paramName, paramName + Constants.MustBeAPositiveInteger);
            }
        }

        /// <summary>
        /// Validate argument is equal or greater then number.
        /// </summary>
        /// <param name="argument">Argument that will be validate.</param>
        /// <param name="number">Minimum value.</param>
        /// <param name="paramName">Argument name.</param>
        public static void ValidateIsEqualOrGreaterThan(int argument, int number, string paramName)
        {
            if (argument < number)
            {
                throw new ArgumentOutOfRangeException(paramName, string.Format(Constants.MustBeEqualOrGreaterThanFormat, paramName, number));
            }
        }
    }
}