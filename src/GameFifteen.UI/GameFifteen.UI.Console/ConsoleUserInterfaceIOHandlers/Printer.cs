// <copyright file="Printer.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Printer class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console.ConsoleUserInterfaceIOHandlers
{
    using System;

    /// <summary>
    /// Printer class - prints on the console.
    /// </summary>
    internal class Printer : IPrinter
    {
        /// <summary>
        /// Holds the current line of the cursor.
        /// </summary>
        private int currentLineCursor;

        /// <summary>
        /// The method prints in the console.
        /// </summary>
        /// <param name="obj">Object to be printed.</param>
        public void Print(object obj)
        {
            Console.Write(obj);
        }

        /// <summary>
        /// The method prints line in the console.
        /// </summary>
        /// <param name="obj">Object to be printed.</param>
        public void PrintLine(object obj)
        {
            Console.WriteLine(obj);
        }

        /// <summary>
        /// The method sets cursor at top left position.
        /// </summary>
        public void SetCursorTopBoard()
        {
            Console.SetCursorPosition(0, 1);
        }

        /// <summary>
        /// The method sets cursor at bottom left position.
        /// </summary>
        public void SetCursorBottomBoard()
        {
            Console.SetCursorPosition(0, Console.CursorTop + 1);
        }

        /// <summary>
        /// The method clears the console.
        /// </summary>
        public void ClearBoard()
        {
            Console.Clear();
        }

        /// <summary>
        /// The method clears line in the console.
        /// </summary>
        public void ClearLine()
        {
            this.currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, this.currentLineCursor);
        }

        /// <summary>
        /// The method clears message of the console.
        /// </summary>
        public void ClearMessages()
        {
            this.currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            for (int i = 0; i < 10; i++)
            {
                Console.Write(new string(' ', Console.WindowWidth));
            }
           
            Console.SetCursorPosition(0, this.currentLineCursor);
        }
    }
}