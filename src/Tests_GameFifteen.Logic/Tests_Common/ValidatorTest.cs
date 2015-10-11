// <copyright file="ValidatorTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ValidatorTest class.
// </summary>
// <author>GameFifteen2Team</author>

namespace Tests_Common
{
    using System;
    using GameFifteen.Logic.Common;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// The ValidatorTest class tests Validator class.
    /// </summary>
    [TestClass]
    public class ValidatorTest
    {
        /// <summary>
        /// The method tests if exception is thrown when null object is provided and must not be null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
          "Argument name cannot be null!")]
        public void NullArgumentInMehodValidateIsNotNull()
        {
            Validator.ValidateIsNotNull(null);
        }

        /// <summary>
        /// The method tests if exception is NOT thrown when not null object is provided and must not be null.
        /// </summary>
        [TestMethod]
        public void ExpectNotToThrowWhenObjectIsPassedToMethodValidateIsNotNull()
        {
            Validator.ValidateIsNotNull(new object());
        }

        /// <summary>
        /// The method tests if exception is thrown when non positive integer is checked for positive one.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
          "Parameter must be a positive integer")]
        public void NegativeIntegerLikeParameterInMehodValidateIsPositiveInteger()
        {
            const int NumberNegative = -1;
            const string Name = "Parameter";
            Validator.ValidateIsPositiveInteger(NumberNegative, Name);
        }

        /// <summary>
        /// The method tests if exception is NOT thrown when positive integer is checked for positive one.
        /// </summary>
        [TestMethod]
        public void ExpectNotToThrowWhenPositiveIntegerIsPassedToValidateIsPositiveInteger()
        {
            const int NumberPositiove = 1;
            const string Name = "Parameter";
            Validator.ValidateIsPositiveInteger(NumberPositiove, Name);
        }

        /// <summary>
        /// The method tests if exception is NOT thrown when fist parameter is greater than second one.
        /// </summary>
        [TestMethod]
        public void ExpectNotToThrowWhenFirstParameterIsGreaterThanSecondInMethodValidateIsEqualOrGreaterThan()
        {
            const int FirstParameter = 4;
            const int SecondParameter = 3;
            Validator.ValidateIsEqualOrGreaterThan(FirstParameter, SecondParameter, "Parameter");
        }

        /// <summary>
        /// The method tests if exception is NOT thrown when fist parameter is equal to the second one.
        /// </summary>
        [TestMethod]
        public void ExpectNotToThrowWhenFirstParameterIsEqualToSecondInMethodValidateIsEqualOrGreaterThan()
        {
            const int FirstParameter = 4;
            const int SecondParameter = 4;
            Validator.ValidateIsEqualOrGreaterThan(FirstParameter, SecondParameter, "Parameter");
        }

        /// <summary>
        /// The method tests if exception is thrown when fist parameter is NOT greater than second one.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
          "Parameter must be equal or greater than 3")]
        public void ThrowExeptionsWhenFirstParameterIsGreaterThanSecondInMethodValidateIsEqualOrGreaterThan()
        {
            const int FirstParameter = 2;
            const int SecondParameter = 3;
            Validator.ValidateIsEqualOrGreaterThan(FirstParameter, SecondParameter, "Parameter");
        }
    }
}