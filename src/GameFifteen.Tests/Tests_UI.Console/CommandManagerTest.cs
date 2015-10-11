namespace GameFifteen.Tests.UI.Console
{
    using System;
    using GameFifteen.UI.Console;
    using GameFifteen.UI.Console.CommandFactory;
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
            var commandManager = new CommandManager();
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
            var result = commandManager.GetCommand("Invalid");

            Assert.IsInstanceOfType(result, typeof(IncorrectCommand));
        }

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
