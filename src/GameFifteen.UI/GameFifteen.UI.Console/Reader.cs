namespace GameFifteen.UI.Console
{
    using System;

    internal class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        public string[] ParseInput(string userInput)
        {
            string[] handleUserInput = new string[] { string.Empty, string.Empty };
            var userCommandAndTarget = userInput.Split(' ');
            string userCommand = userCommandAndTarget[0];
            handleUserInput[0] = userCommand;

            if (userCommandAndTarget.Length == 2)
            {
                string userTarget = userCommandAndTarget[1];
                handleUserInput[1] = userTarget;
            }

            return handleUserInput;
        }
    }
}