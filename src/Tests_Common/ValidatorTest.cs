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
            Validator.ValidateIsNotNull(null, Constants.ArgumentName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
          "Parametar must be a positive integer")]
        public void NegativeIntegerLikeParameterInMehodValidateIsPositiveInteger()
        {
            int numberNegative = -1;
            string name = "Parametar";
            Validator.ValidateIsNotNull(numberNegative, name);
        }
        
    }
}
