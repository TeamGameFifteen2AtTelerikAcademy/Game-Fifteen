using GameFifteen.Logic.Commands;
using GameFifteen.Logic.Common;
using GameFifteen.UI.Console.Commands;
using Moq;

namespace GameFifteen.Tests.UI.Console
{
    using System;
    using System.Security.Cryptography.X509Certificates;
    using GameFifteen.Logic.Memento;
    using GameFifteen.Logic.Scoreboards;
    using GameFifteen.UI.Console;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void ExpectEngineToRunProperlyAndForcedExitAfterTwoSteps()
        {
            var reader = MockStorage.GetReader("exit");

            var engine = new Engine(

                MockStorage.GetGame(),
                new Scoreboard(),
                MockStorage.GetPrinter(),
                reader,
                new CommandManager(),
                new BoardHistory()

                );

            engine.Run();
        }

        [TestMethod]
        public void ExpectEngineToRunProperlyWhenTopCommandIsCalled()
        {
            var reader = MockStorage.GetReader("top");

            var engine = new Engine(

                MockStorage.GetGame(),
                new Scoreboard(),
                MockStorage.GetPrinter(),
                reader,
                new CommandManager(),
                new BoardHistory()

                );

            engine.Run();
        }

        [TestMethod]
        public void ExpectEngineToRunProperlyWhenMoveCommandIsCalled()
        {
            var reader = MockStorage.GetReader("move 3");

            var engine = new Engine(

                MockStorage.GetGame(),
                new Scoreboard(),
                MockStorage.GetPrinter(),
                reader,
                new CommandManager(),
                new BoardHistory()

                );

            engine.Run();
        }

        [TestMethod]
        public void ExpectEngineToRunProperlyWhenInvalidMoveCommandIsCalled()
        {
            var reader = MockStorage.GetReader("move -1");

            var engine = new Engine(

                MockStorage.GetGame(),
                new Scoreboard(),
                MockStorage.GetPrinter(),
                reader,
                new CommandManager(),
                new BoardHistory()

                );

            engine.Run();
        }

        [TestMethod]
        public void ExpectEngineToRunProperlyWhenRestartCommandIsCalled()
        {
            var reader = MockStorage.GetReader("restart");

            var engine = new Engine(

                MockStorage.GetGame(),
                new Scoreboard(),
                MockStorage.GetPrinter(),
                reader,
                new CommandManager(),
                new BoardHistory()

                );

            engine.Run();
        }

        [TestMethod]
        public void ExpectToExecuteGameOverWhenGameIsSolved()
        {
            var reader = MockStorage.GetReader("move 3");

            var engine = new Engine(

                MockStorage.GetSolvedGame(),
                MockStorage.GetScoreboard(),
                MockStorage.GetPrinter(),
                reader,
                new CommandManager(),
                new BoardHistory()

                );

            engine.Run();
        }

        [TestMethod]
        public void ExpectToExecuteGameOverAndAddToScoreBoard()
        {
            var reader = MockStorage.GetReader("move 3");

            var engine = new Engine(

                MockStorage.GetSelfSolvingGameAfterOneMove(),
               new Scoreboard(), 
                MockStorage.GetPrinter(),
                reader,
                new CommandManager(),
                new BoardHistory()

                );

            engine.Run();
        }

        [TestMethod]
        public void ExpectMoveCommandToReachIfStatement()
        {
            var context = MockStorage.GetCommandContext();

            var game = MockStorage.GetGameWithInvalidMove();

            var moveCommand = new MoveCommand();
            moveCommand.Execute(context);
        }

        [TestMethod]
        public void ExpectUndoCommandToWork()
        {
            var context = MockStorage.GetCommandContext();

            var game = MockStorage.GetGameWithInvalidMove();

            var moveCommand = new UndoCommand();
            moveCommand.Execute(context);

        }
    }
}
