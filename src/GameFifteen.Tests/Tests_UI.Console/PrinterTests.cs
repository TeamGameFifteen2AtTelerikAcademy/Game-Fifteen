// <copyright file="PrinterTests.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Unit testing UI Console.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Tests.UI.Console
{
    using System.IO;
    using GameFifteen.Logic.Frames;
    using GameFifteen.Logic.Tiles.Contracts;
    using GameFifteen.UI.Console;
    using GameFifteen.UI.Console.ConsoleUserInterfaceIOHandlers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Class test PrinterTests.
    /// </summary>
    [TestClass]
    public class PrinterTests
    {
        /// <summary>
        /// Test that expect Print method to work correctly with frame.
        /// </summary>
        [TestMethod]
        public void ExpectPrintMethodToWorkCorrectlyWithFrame()
        {
            var frame = new Frame(new ITile[3, 3]);
            var printer = new Printer();
            printer.Print(frame);
        }

        /// <summary>
        /// Test that expect PrintLine method to work correctly with frame.
        /// </summary>
        [TestMethod]
        public void ExpectPrintLineMethodToWorkCorrectlyWithFrame()
        {
            var frame = new Frame(new ITile[3, 3]);
          
            var printer = new Printer();
            printer.PrintLine(frame);
        }

        /// <summary>
        /// Test that expect set cursor bottom board to invoke console set cursor position and throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void ExpectSetCursorBottomBoardToInvokeConsoleSetCursorPositionAndThrow()
        {
            var printer = new Printer();
            printer.SetCursorBottomBoard();
        }

        /// <summary>
        /// Test that expect set cursor top board to invoke console set cursor position and throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void ExpectSetCursorTopBoardToInvokeConsoleSetCursorPositionAndThrow()
        {
            var printer = new Printer();
            printer.SetCursorTopBoard();
        }

        /// <summary>
        /// Test that expect clear board to invoke console clear and throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void ExpectClearBoardToInvokeConsoleSClearAndThrow()
        {
            var printer = new Printer();
            printer.ClearBoard();
        }

        /// <summary>
        /// Test that expect clear line  to invoke console set cursor position and throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void ExpectClearLineToInvokeConsoleSetCursorPositionAndThrow()
        {
            var printer = new Printer();
            printer.ClearLine();
        }

        /// <summary>
        /// Test that expect clear message to invoke console set cursor position and throw.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void ExpectClearMessagesToInvokeConsoleSetCursorPositionAndThrow()
        {
            var printer = new Printer();
            printer.ClearMessages();
        }
    }
}