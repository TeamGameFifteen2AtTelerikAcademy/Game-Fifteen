// <copyright file="CommandManagerTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Unit testing UI Console.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Tests.UI.Console
{
    using System;
    using GameFifteen.UI.Console;
    using GameFifteen.UI.Console.CommandFactory;
    using GameFifteen.UI.Console.Commands;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class test CommandManagerTest.
    /// </summary>
    [TestClass]
    public class CommandManagerTest
    {
        /// <summary>
        /// Test that expect initializing to not throw.
        /// </summary>
        [TestMethod]
        public void ExpectInitializingToNotThrow()
        {
            var commandManager = new CommandManager();
        }

        /// <summary>
        /// Test that expect get command to return restart command when valid string.
        /// </summary>
        [TestMethod]
        public void ExpectGetCommandToReturnRestartCommandWhenValidString()
        {
            var commandManager = new CommandManager();
            var result = commandManager.GetCommand("Restart");

            Assert.IsInstanceOfType(result, typeof(RestartCommand));
        }

        /// <summary>
        /// Test that expect get command to return top command when valid string.
        /// </summary>
        [TestMethod]
        public void ExpectGetCommandToReturnTopCommandWhenValidString()
        {
            var commandManager = new CommandManager();
            var result = commandManager.GetCommand("Top");

            Assert.IsInstanceOfType(result, typeof(ShowScoresCommand));
        }

        /// <summary>
        /// Test that expect get command to return exit command when valid string.
        /// </summary>
        [TestMethod]
        public void ExpectGetCommandToReturnExitCommandWhenValidString()
        {
            var commandManager = new CommandManager();
            var result = commandManager.GetCommand("Exit");

            Assert.IsInstanceOfType(result, typeof(ExitCommand));
        }

        /// <summary>
        /// Test that expect get command to return undo command when valid string.
        /// </summary>
        [TestMethod]
        public void ExpectGetCommandToReturnUndoCommandWhenValidString()
        {
            var commandManager = new CommandManager();
            var result = commandManager.GetCommand("Undo");

            Assert.IsInstanceOfType(result, typeof(UndoCommand));
        }

        /// <summary>
        /// Test that expect get command to return move command when valid string.
        /// </summary>
        [TestMethod]
        public void ExpectGetCommandToReturnMoveCommandWhenValidString()
        {
            var commandManager = new CommandManager();
            var result = commandManager.GetCommand("Move");

            Assert.IsInstanceOfType(result, typeof(MoveCommand));
        }

        /// <summary>
        /// Test that expect get command to return incorrect command when invalid string.
        /// </summary>
        [TestMethod]
        public void ExpectGetCommandToReturnIncorrectCommandWhenInvalidString()
        {
            var commandManager = new CommandManager();
            var result = commandManager.GetCommand("Invalid");

            Assert.IsInstanceOfType(result, typeof(IncorrectCommand));
        }

        /// <summary>
        /// Test that expect get command to throw if somehow passed invalid string.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        //// In real life it will never be invoked with invalid string, because of the Parser.
        public void ExpectGetCommandToThrowIfSomehowPassedInvalidString()
        {
            var commandManager = new CommandManager();
            var result = commandManager.GetCommand("42");
        }
    }
}
