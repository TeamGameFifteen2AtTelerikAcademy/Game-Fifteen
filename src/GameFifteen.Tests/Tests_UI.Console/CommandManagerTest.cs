﻿namespace GameFifteen.Tests.UI.Console
{
    using GameFifteen.UI.Console;
    using GameFifteen.UI.Console.Commands;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class CommandManagerTest
    {
        [TestMethod]
        public void ExpectInitializingToNotThrow()
        {
            var commandManager = new CommandManager();
        }

        [TestMethod]
        public void ExpectGetCommandToReturnRestartCommandWhenValidString()
        {
            var commandManager= new CommandManager();
            var result = commandManager.GetCommand("Restart");

            Assert.IsInstanceOfType(result, typeof(RestartCommand));
        }

        [TestMethod]
        public void ExpectGetCommandToReturnTopCommandWhenValidString()
        {
            var commandManager = new CommandManager();
            var result = commandManager.GetCommand("Top");

            Assert.IsInstanceOfType(result, typeof(ShowScoresCommand));
        }

        [TestMethod]
        public void ExpectGetCommandToReturnExitCommandWhenValidString()
        {
            var commandManager = new CommandManager();
            var result = commandManager.GetCommand("Exit");

            Assert.IsInstanceOfType(result, typeof(ExitCommand));
        }

        [TestMethod]
        public void ExpectGetCommandToReturnUndoCommandWhenValidString()
        {
            var commandManager = new CommandManager();
            var result = commandManager.GetCommand("Undo");

            Assert.IsInstanceOfType(result, typeof(UndoCommand));
        }

        [TestMethod]
        public void ExpectGetCommandToReturnMoveCommandWhenValidString()
        {
            var commandManager = new CommandManager();
            var result = commandManager.GetCommand("Move");

            Assert.IsInstanceOfType(result, typeof(MoveCommand));
        }

        [TestMethod]
        public void ExpectGetCommandToReturnIncorrectCommandWhenInvalidString()
        {
            var commandManager = new CommandManager();
            var result = commandManager.GetCommand("42");

            Assert.IsInstanceOfType(result, typeof(IncorrectCommand));
        }
    }
}
