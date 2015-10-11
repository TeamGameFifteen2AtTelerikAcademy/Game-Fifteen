// <copyright file="EngineTests.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Unit testing UI Console.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Tests.UI.Console
{
    using System.Linq;
    using GameFifteen.Logic.Memento;
    using GameFifteen.Logic.Scoreboards;
    using GameFifteen.UI.Console.CommandFactory;
    using GameFifteen.UI.Console.Commands;
    using GameFifteen.UI.Console.Engine;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class test EngineTests.
    /// </summary>
    [TestClass]
    public class EngineTests
    {
        /// <summary>
        /// Test that expect engine to return properly and forced exit after two steps.
        /// </summary>
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
                new BoardHistory());
            engine.Run();
        }

        /// <summary>
        /// Test that expect engine to run properly when top command is called.
        /// </summary>
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
                new BoardHistory());
            engine.Run();
        }

        /// <summary>
        /// Test that expect engine to run properly when move command is called.
        /// </summary>
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
                new BoardHistory());
            engine.Run();
        }

        /// <summary>
        /// Test that expect engine to run properly when invalid move command is called.
        /// </summary>
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
                new BoardHistory());
            engine.Run();
        }

        /// <summary>
        /// Test that expect engine to run properly when restart command is called.
        /// </summary>
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
                new BoardHistory());
            engine.Run();
        }

        /// <summary>
        /// Test that expect engine to run properly when give invalid input for command.
        /// </summary>
        [TestMethod]
        public void ExpectEngineToRunProperlyWhenGivenInvalidInputForCommand()
        {
            var reader = MockStorage.GetReader("theyAreGreen");

            var engine = new Engine(
                MockStorage.GetGame(),
                new Scoreboard(),
                MockStorage.GetPrinter(),
                reader,
                new CommandManager(),
                new BoardHistory());
            engine.Run();
        }

        /// <summary>
        /// Test that expect to execute game over when game is solved.
        /// </summary>
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
                new BoardHistory());

            engine.Run();
        }

        /// <summary>
        /// Test that expect to execute game over and add to score board.
        /// </summary>
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
                new BoardHistory());

            engine.Run();
        }

        /// <summary>
        /// Test that expect to add to score board one move.
        /// </summary>
        [TestMethod]
        public void ExpectToAddToScoreBoardOneMove()
        {
            var reader = MockStorage.GetReader("move 3");
            var scoreboard = new Scoreboard();

            var engine = new Engine(
                MockStorage.GetSelfSolvingGameAfterOneMove(),
                scoreboard,
                MockStorage.GetPrinter(),
                reader,
                new CommandManager(),
                new BoardHistory());

            engine.Run();
            Assert.AreEqual(1, scoreboard.GetTopScores().First().Moves);
        }

        /// <summary>
        /// Test that expect move command to reach if statement.
        /// </summary>
        [TestMethod]
        public void ExpectMoveCommandToReachIfStatement()
        {
            var context = MockStorage.GetCommandContext();

            var game = MockStorage.GetGameWithInvalidMove();

            var moveCommand = new MoveCommand();
            moveCommand.Execute(context);
        }

        /// <summary>
        /// Test that expect undo command to work.
        /// </summary>
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
