// <copyright file="IPrinter.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for IPrinter.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console
{
    /// <summary>
    /// Interface for IPrinter.
    /// </summary>
    public interface IPrinter
    {
        /// <summary>
        /// The method should print in corresponding environment.
        /// </summary>
        /// <param name="obj">Object to be printed.</param>
        void Print(object obj);

        /// <summary>
        /// The method should print new line in corresponding environment.
        /// </summary>
        /// <param name="obj">Object to be printed.</param>
        void PrintLine(object obj);

        /// <summary>
        /// The method should clear the board in corresponding environment.
        /// </summary>
        void ClearBoard();

        /// <summary>
        /// The method should set the cursor in the top of the board in corresponding environment.
        /// </summary>
        void SetCursorTopBoard();

        /// <summary>
        /// The method should set clear line.
        /// </summary>
        void ClearLine();

        /// <summary>
        /// The method should set the cursor in the bottom of the board in corresponding environment.
        /// </summary>
        void SetCursorBottomBoard();

        /// <summary>
        /// The method should clear messages in corresponding environment.
        /// </summary>
        void ClearMessages();
    }
}