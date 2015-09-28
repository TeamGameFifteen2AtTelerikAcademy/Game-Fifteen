namespace GameFifteen.Logic.Common
{
    using System;

    public static class Validator
    {
        public static void ValidateIsNotNull(object argument, string argumentName = Constants.ArgumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName, string.Format(Constants.CannotBeNullFormat, argumentName));
            }
        }
    }
}