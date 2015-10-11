// <copyright file="CommandContextTests.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Unit testing UI Console.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Tests.UI.Console
{
    using GameFifteen.Logic.Commands;
    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Frames;
    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Games;
    using GameFifteen.Logic.Games.Contracts;
    using GameFifteen.Logic.Memento;
    using GameFifteen.Logic.Movers;
    using GameFifteen.Logic.Scoreboards;
    using GameFifteen.Logic.Scoreboards.Contracts;
    using GameFifteen.Logic.Tiles.Contracts;
    using GameFifteen.UI.Console;
    using GameFifteen.UI.Console.CommandFactory;
    using GameFifteen.UI.Console.Commands;
    using GameFifteen.UI.Console.ConsoleUserInterfaceIOHandlers;
    using GameFifteen.UI.Console.GameContext;
    using GameFifteen.UI.Console.GameInitializer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Class test CommandContextTests.
    /// </summary>
    [TestClass]
    public class CommandContextTests
    {
        /// <summary>
        /// Initializes a new instance of the CommandContextTests class.
        /// </summary>
        public CommandContextTests()
        {
            var printer = new Printer();

            var reader = new Reader();

            var gameInitializator = new GameInitializer(printer, reader);

            var game = new Game(new Frame(new ITile[3, 3]), new ClassicMover());

            var scoreboard = new Scoreboard();

            var commandManager = new CommandManager();

            var boardHistory = new BoardHistory();

            this.Instance = new CommandContext(game, scoreboard, boardHistory);
        }

        /// <summary>
        /// Gets or sets Instance.
        /// </summary>
        /// <value>Instance of type CommandContext.</value>
        public CommandContext Instance { get; set; }

        /// <summary>
        /// Test that expect command context constructor to set moves to zero.
        /// </summary>
        [TestMethod]
        public void ExpectCommandContextConstructorToSetMovesToZero()
        {
            var moves = this.Instance.Moves;
            Assert.AreEqual(0, moves);
        }

        /// <summary>
        /// Test that expect constructor to set to zero.
        /// </summary>
        [TestMethod]
        public void ExpectConstructorToSetMovesToZeroMoq()
        {
            var context = new Mock<ICommandContext>();
            var moves = context.Object.Moves;
            Assert.AreEqual(0, moves);
        }

        /// <summary>
        /// Test that expect constructor to set to game.
        /// </summary>
        [TestMethod]
        public void ExpectConstructorToSetGame()
        {
            var game = this.Instance.Game;
            Assert.IsInstanceOfType(game, typeof(IGame));
        }

        [TestMethod]

        /// <summary>
        /// Test that expect constructor to set to scoreboard.
        /// </summary>
        public void ExpectConstructorToSetScoreboard()
        {
            var scoreboard = this.Instance.ScoreboardInfo;
            Assert.IsInstanceOfType(scoreboard, typeof(IScoreboard));
        }

        /// <summary>
        /// Test that expect constructor to set to board history.
        /// </summary>
        [TestMethod]
        public void ExpectConstructorToSetBoardHistory()
        {
            var history = this.Instance.BoardHistory;
            Assert.IsInstanceOfType(history, typeof(IMemento));
        }

        /// <summary>
        /// Test that expect message to be empty string before starting the game.
        /// </summary>
        [TestMethod]
        public void ExpectMessageToBeEmptyStringBeforeStartingTheGame()
        {
            var message = this.Instance.Message;
            Assert.AreEqual(null, message);
        }

        /// <summary>
        /// Test that expect message to be correct when show scores command is executed.
        /// </summary>
        [TestMethod]
        public void ExpectMessageToBeCorrectWhenShowScoresCommandIsExecuted()
        {
            var commandTop = new ShowScoresCommand();
            commandTop.Execute(this.Instance);
            Assert.AreEqual(this.Instance.ScoreboardInfo.ToString(), this.Instance.Message);
        }

        /// <summary>
        /// Test that expect message to be correct when incorrect command is executed.
        /// </summary>
        [TestMethod]
        public void ExpectMessageToBeCorrectWhenIncorrectCommandIsExecuted()
        {
            var commandTop = new IncorrectCommand();
            commandTop.Execute(this.Instance);
            Assert.AreEqual(Constants.InvalidCommandMessage, this.Instance.Message);
        }

        /// <summary>
        /// Test that expect message to be correct when move command is executed.
        /// </summary>
        [TestMethod]
        public void ExpectMessageToBeCorrectWhenMoveCommandIsExecuted()
        {
            // We cant know how are ordered the tiles and witch can be moved, so we mock the Game.Move() method
            this.PrepareMockingGameAndMementoForTestingMoveCommand();

            var moveCommand = new MoveCommand();
            moveCommand.Execute(this.Instance);

            Assert.AreEqual(string.Empty, this.Instance.Message);
        }

        /// <summary>
        /// Test that expect moves to increase by one when move command is executed once.
        /// </summary>
        [TestMethod]
        public void ExpectMovesToIncreaseByOneWhenMoveCommandIsExecutedOnce()
        {
            this.PrepareMockingGameAndMementoForTestingMoveCommand();
            var currentMoves = this.Instance.Moves;

            var moveCommand = new MoveCommand();
            moveCommand.Execute(this.Instance);

            Assert.AreEqual(currentMoves + 1, this.Instance.Moves);
        }

        /// <summary>
        /// Test that expect moves to increase by five when move command is executed five times.
        /// </summary>
        [TestMethod]
        public void ExpectMovesToIncreaseByFiveWhenMoveCommandIsExecutedFiveTimes()
        {
            this.PrepareMockingGameAndMementoForTestingMoveCommand();
            var currentMoves = this.Instance.Moves;

            var moveCommand = new MoveCommand();
            for (int i = 0; i < 5; i++)
            {
                moveCommand.Execute(this.Instance);
            }

            Assert.AreEqual(currentMoves + 5, this.Instance.Moves);
        }

        /// <summary>
        /// Method prepare mocking game and memento for testing move command.
        /// </summary>
        private void PrepareMockingGameAndMementoForTestingMoveCommand()
        {
            var mockedGame = new Mock<IGame>();
            mockedGame.Setup(x => x.Move(It.IsAny<string>()))
                .Returns(true);

            var mockedMemento = new Mock<IMemento>();
            mockedMemento.Setup(y => y.SaveBoardState(It.IsAny<IFrame>()))
                .Verifiable();

            this.Instance.Game = mockedGame.Object;
            this.Instance.BoardHistory = mockedMemento.Object;
            this.Instance.SelectedTileLabel = "2";
        }
    }
}
