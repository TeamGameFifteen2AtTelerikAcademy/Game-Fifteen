using System;
using System.Runtime.CompilerServices;
using GameFifteen.Logic.Commands;
using GameFifteen.Logic.Frames;
using GameFifteen.Logic.Frames.Contracts;
using GameFifteen.Logic.Tiles.Contracts;
using GameFifteen.UI.Console;

namespace GameFifteen.Tests.UI.Console
{
    using Logic.Games.Contracts;
    using Moq;

    public class MockStorage
    {
        public static IPrinter GetPrinter()
        {
            var mockedPriner = new Mock<IPrinter>();

            mockedPriner.Setup(x => x.Print(It.IsAny<object>()))
                .Verifiable();

            mockedPriner.Setup(x => x.PrintLine(It.IsAny<object>()))
                .Verifiable();
            return mockedPriner.Object;
        }

        public static IReader GetReader(string value)
        {
            var mockedReader = new Mock<IReader>();
            var numberOfCalls = 2;
            mockedReader.Setup(x => x.ReadLine())
                .Callback(() =>
                {
                    if (numberOfCalls == 0)
                    {
                        value = "Exit";
                    }
                    else
                    {
                        value = It.IsAny<string>();
                        numberOfCalls--;

                    }
                })
                .Returns(value);

            mockedReader.Setup(x => x.ParseInput(It.IsAny<string>()))
                .Returns(new Reader().ParseInput(value));

            return mockedReader.Object;
        }

        public static IGame GetGame()
        {
            var mockedGame = new Mock<IGame>();
            var numberOfCalls = 2;
            bool isOver = false;


            mockedGame.Setup(x => x.Move(It.IsAny<string>()))
                .Returns(true);

            mockedGame.Setup(x => x.Shuffle())
                .Verifiable();

            mockedGame.Setup(x => x.Frame)
                .Returns(new Frame(new ITile[3, 3]));
            
            return mockedGame.Object;
        }

        public static IGame GetSolvedGame()
        {
            var mockedGame = new Mock<IGame>();
            var numberOfCalls = 2;
            bool isOver = false;


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

        public static ICommandManager GeCommandManager()
        {
            var mockedManager = new Mock<ICommandManager>();



            return mockedManager.Object;
        }
    }
}
