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
    /// Summary description for CommandContextTests
    /// </summary>
    [TestClass]
    public class CommandContextTests
    {
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

        public CommandContext Instance { get; set; }

        [TestMethod]
        public void ExpectCommandContextConstructorToSetMovesToZero()
        {
            var moves = this.Instance.Moves;
            Assert.AreEqual(0, moves);
        }

        [TestMethod]
        public void ExpectConstructorToSetMovesToZeroMoq()
        {
            var context = new Mock<ICommandContext>();
            var moves = context.Object.Moves;
            Assert.AreEqual(0, moves);
        }

        [TestMethod]
        public void ExpectConstructorToSetGame()
        {
            var game = this.Instance.Game;
            Assert.IsInstanceOfType(game, typeof(IGame));
        }

        [TestMethod]
        public void ExpectConstructorToSetScoreboard()
        {
            var scoreboard = this.Instance.ScoreboardInfo;
            Assert.IsInstanceOfType(scoreboard, typeof(IScoreboard));
        }

        [TestMethod]
        public void ExpectConstructorToSetBoardHistory()
        {
            var history = this.Instance.BoardHistory;
            Assert.IsInstanceOfType(history, typeof(IMemento));
        }

        [TestMethod]
        public void ExpectMessageToBeEmptyStringBeforeStartingTheGame()
        {
            var message = this.Instance.Message;
            Assert.AreEqual(null, message);
        }

        [TestMethod]
        public void ExpectMessageToBeCorrectWhenShowScoresCommandIsExecuted()
        {
            var commandTop = new ShowScoresCommand();
            commandTop.Execute(this.Instance);
            Assert.AreEqual(this.Instance.ScoreboardInfo.ToString(), this.Instance.Message);
        }

        [TestMethod]
        public void ExpectMessageToBeCorrectWhenIncorrectCommandIsExecuted()
        {
            var commandTop = new IncorrectCommand();
            commandTop.Execute(this.Instance);
            Assert.AreEqual(Constants.InvalidCommandMessage, this.Instance.Message);
        }

        [TestMethod]
        public void ExpectMessageToBeCorrectWhenMoveCommandIsExecuted()
        {
            // We cant know how are ordered the tiles and witch can be moved, so we mock the Game.Move() method
            this.PrepareMockingGameAndMementoForTestingMoveCommand();

            var moveCommand = new MoveCommand();
            moveCommand.Execute(this.Instance);

            Assert.AreEqual(string.Empty, this.Instance.Message);
        }

        [TestMethod]
        public void ExpectMovesToIncreaseByOneWhenMoveCommandIsExecutedOnce()
        {
            this.PrepareMockingGameAndMementoForTestingMoveCommand();
            var currentMoves = this.Instance.Moves;

            var moveCommand = new MoveCommand();
            moveCommand.Execute(this.Instance);

            Assert.AreEqual(currentMoves + 1, this.Instance.Moves);
        }

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
