// <copyright file="MockStorage.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Mocking UI Console.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Tests.UI.Console
{
    using GameFifteen.UI.Console.ConsoleUserInterfaceIOHandlers;
    using Logic.Commands;
    using Logic.Frames;
    using Logic.Frames.Contracts;
    using Logic.Games.Contracts;
    using Logic.Memento;
    using Logic.Scoreboards.Contracts;
    using Logic.Tiles.Contracts;
    using Moq;

    /// <summary>
    /// Class MockStorage.
    /// </summary>
    public class MockStorage
    {
        /// <summary>
        /// Private field result of type string.
        /// </summary>
        private static string result;

        /// <summary>
        /// Method get reader.
        /// </summary>
        /// <param name="value">Type string.</param>
        /// <returns>Returns mockedPrinter.</returns>
        public static IReader GetReader(string value)
        {
            var mockedReader = new Mock<IReader>();
            var numberOfCalls = 2;
            result = value;
            var parsedInput = new string[3];
            mockedReader.Setup(x => x.ReadLine())
                .Callback(() =>
                {
                    if (numberOfCalls == 0)
                    {
                        result = "Exit";
                    }
                    else
                    {
                        // Result = It.IsAny<string>();
                        numberOfCalls--;
                    }
                })
                .Returns(() => result);

            mockedReader.Setup(x => x.ParseInput(It.IsAny<string>()))
                .Callback<string>(
            toparse =>
            {
                var simpleReader = new Reader();
                parsedInput = simpleReader.ParseInput(toparse);
            })
                .Returns(() => parsedInput);

            return mockedReader.Object;
        }

        /// <summary>
        /// Method get reader.
        /// </summary>
        /// <returns>Returns mockedPrinter.</returns>
        public static IPrinter GetPrinter()
        {
            var mockedPriner = new Mock<IPrinter>();

            mockedPriner.Setup(x => x.Print(It.IsAny<object>()))
                .Verifiable();

            mockedPriner.Setup(x => x.PrintLine(It.IsAny<object>()))
                .Verifiable();
            return mockedPriner.Object;
        }

        /// <summary>
        /// Method get game.
        /// </summary>
        /// <returns>Returns mockedGame.</returns>
        public static IGame GetGame()
        {
            var mockedGame = new Mock<IGame>();

            mockedGame.Setup(x => x.Move(It.IsAny<string>()))
                .Returns(true);

            mockedGame.Setup(x => x.Shuffle())
                .Verifiable();

            mockedGame.Setup(x => x.Frame)
                .Returns(new Frame(new ITile[3, 3]));

            return mockedGame.Object;
        }

        /// <summary>
        /// Method get solved game.
        /// </summary>
        /// <returns>Returns mockedGame.</returns>
        public static IGame GetSolvedGame()
        {
            var mockedGame = new Mock<IGame>();

            mockedGame.Setup(x => x.Move(It.IsAny<string>()))
                .Returns(true);

            mockedGame.Setup(x => x.Shuffle())
                .Verifiable();

            mockedGame.Setup(x => x.Frame)
                .Returns(new Frame(new ITile[3, 3]));

            mockedGame.Setup(x => x.IsSolved)
                .Returns(true);

            return mockedGame.Object;
        }

        /// <summary>
        /// Method get solving game after one move.
        /// </summary>
        /// <returns>Returns mockedGame.</returns>
        public static IGame GetSelfSolvingGameAfterOneMove()
        {
            var mockedGame = new Mock<IGame>();
            var numberOfCalls = 1;

            mockedGame.Setup(x => x.Move(It.IsAny<string>()))
                .Returns(true);

            mockedGame.Setup(x => x.Shuffle())
                .Verifiable();

            mockedGame.Setup(x => x.Frame)
                .Returns(new Frame(new ITile[3, 3]));

            mockedGame.Setup(x => x.IsSolved)
                .Returns(() =>
                {
                    if (numberOfCalls == 0)
                    {
                        return true;
                    }
                    else
                    {
                        numberOfCalls--;
                        return false;
                    }
                });

            return mockedGame.Object;
        }

        /// <summary>
        /// Method get game with invalid move.
        /// </summary>
        /// <returns>Returns mockedGame.</returns>
        public static IGame GetGameWithInvalidMove()
        {
            var mockedGame = new Mock<IGame>();

            mockedGame.Setup(x => x.Move(It.IsAny<string>()))
                .Returns(false);

            return mockedGame.Object;
        }

        /// <summary>
        /// Method get command context.
        /// </summary>
        /// <returns>Returns mockedContext.</returns>
        public static ICommandContext GetCommandContext()
        {
            var mockedContext = new Mock<ICommandContext>();

            mockedContext.Setup(x => x.Game)
                .Returns(() => MockStorage.GetGameWithInvalidMove());

            mockedContext.Setup(x => x.BoardHistory)
                .Returns(() => MockStorage.GetBoardHistory());

            mockedContext.Setup(x => x.SelectedTileLabel)
                .Returns(() => "3");
            return mockedContext.Object;
        }

        /// <summary>
        /// Method get board history.
        /// </summary>
        /// <returns>Returns memento.</returns>
        public static IMemento GetBoardHistory()
        {
            var memento = new Mock<IMemento>();

            memento.Setup(x => x.SaveBoardState(It.IsAny<IFrame>()))
                .Verifiable();

            memento.Setup(x => x.Undo()).Verifiable();

            return memento.Object;
        }

        /// <summary>
        /// Method get scoreboard.
        /// </summary>
        /// <returns>Returns mocked.</returns>
        public static IScoreboard GetScoreboard()
        {
            var mocked = new Mock<IScoreboard>();

            mocked.Setup(x => x.Add(It.IsAny<int>(), It.IsAny<string>())).Verifiable();

            return mocked.Object;
        }

        /// <summary>
        /// Method get command manager.
        /// </summary>
        /// <returns>Returns mockedManager.</returns>
        public static ICommandManager GeCommandManager()
        {
            var mockedManager = new Mock<ICommandManager>();

            return mockedManager.Object;
        }
    }
}
