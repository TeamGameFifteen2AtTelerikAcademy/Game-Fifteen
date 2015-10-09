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

        /*PEPI
          string parsedString = "";

            mockedReader.Setup(x => x.ParseInput(It.IsAny<string>())).Callback((string y) =>
            {
                var splitInput = y.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (splitInput.Length == 2)
                {
                    if ((splitInput[0] + splitInput[1]).All(char.IsDigit))
                    {
                        parsedString = "pop " + splitInput[0] + " " + splitInput[1];
                    }
                    else
                    {
                        parsedString = "invalidInput";
                    }
                }
                else
                {
                    parsedString = y;
                }
            })
            .Returns(() => parsedString);
            
            
            */

        public static string Result;

        public static IReader GetReader(string value)
        {
            var mockedReader = new Mock<IReader>();
            var numberOfCalls = 1;
            Result = value;
            var parsedInput = new string[3];
            mockedReader.Setup(x => x.ReadLine())
                .Callback(() =>
                {
                    if (numberOfCalls == 0)
                    {
                        Result = "Exit";
                    }
                    else
                    {
                        // Result = It.IsAny<string>();
                        numberOfCalls--;
                    }
                })
                .Returns(() => Result);

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
