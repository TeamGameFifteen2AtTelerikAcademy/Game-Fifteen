using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen.Logic.Common;

namespace Tests_Common
{
    [TestClass]
    public class ValidatorTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
          "Argument name cannot be null!")]
        public void NullArgumentInMehodValidateIsNotNull()
        {
            Validator.ValidateIsNotNull(null);
        }

        [TestMethod]
        public void ExpectNotToThrowWhenObjectIsPassedToMethodValidateIsNotNull()
        {
            Validator.ValidateIsNotNull(new object());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
          "Parameter must be a positive integer")]
        public void NegativeIntegerLikeParameterInMehodValidateIsPositiveInteger()
        {
            const int NumberNegative = -1;
            const string Name = "Parameter";
            Validator.ValidateIsPositiveInteger(NumberNegative, Name);
        }

        [TestMethod]
        public void ExpectNotToThrowWhenPositiveIntegerIsPassedToValidateIsPositiveInteger()
        {
            const int NumberPositiove = 1;
            const string Name = "Parameter";
            Validator.ValidateIsPositiveInteger(NumberPositiove, Name);
        }

        [TestMethod]
        public void ExpectNotToThrowWhenFirstParameterIsGreaterThanSecondInMethodValidateIsEqualOrGreaterThan()
        {
            const int firstParameter = 4;
            const int secondParameter = 3;
            Validator.ValidateIsEqualOrGreaterThan(firstParameter, secondParameter, "Parameter");
        }

        [TestMethod]
        public void ExpectNotToThrowWhenFirstParameterIsEqualToSecondInMethodValidateIsEqualOrGreaterThan()
        {
            const int firstParameter = 4;
            const int secondParameter = 4;
            Validator.ValidateIsEqualOrGreaterThan(firstParameter, secondParameter, "Parameter");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
          "Parameter must be equal or greater than 3")]
        public void ThrowExeptionsWhenFirstParameterIsGreaterThanSecondInMethodValidateIsEqualOrGreaterThan()
        {
            const int firstParameter = 2;
            const int secondParameter = 3;
            Validator.ValidateIsEqualOrGreaterThan(firstParameter, secondParameter, "Parameter");
        }
    }
}
