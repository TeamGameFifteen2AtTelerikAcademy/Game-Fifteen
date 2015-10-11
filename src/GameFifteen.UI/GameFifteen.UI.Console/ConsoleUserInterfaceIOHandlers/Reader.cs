// <copyright file="Reader.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Reader class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console.ConsoleUserInterfaceIOHandlers
{
    using System;
    using System.Globalization;

    using GameFifteen.UI.Console.Commands;

    /// <summary>
    /// Reader class - reads from the console.
    /// </summary>
    internal class Reader : IReader
    {
        /// <summary>
        /// The method reads line from the console.
        /// </summary>
        /// <returns>Console line as string.</returns>
        public string ReadLine()
        {
            return Console.ReadLine();
        }

        /// <summary>
        /// The methods parses the input from the console.
        /// </summary>
        /// <param name="userInput">The user input.</param>
        /// <returns>Array of strings.</returns>
        public string[] ParseInput(string userInput)
        {
            var handleUserInput = new string[2];
            var userCommandAndTarget = userInput.Split(' ');
            string userCommand = userCommandAndTarget[0];
            userCommand = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(userCommand);

            if (userCommandAndTarget.Length == 2)
            {
                string userTarget = userCommandAndTarget[1];
                handleUserInput[1] = userTarget;
            }

            if (!Enum.IsDefined(typeof(UserCommands), userCommand))
            {
                userCommand = "Invalid";
            }

            handleUserInput[0] = userCommand;
            return handleUserInput;
        }
    }
}