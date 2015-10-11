// <copyright file="GameInitializerTests.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Unit testing UI Console.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Tests.UI.Console
{
    using GameFifteen.Logic.Games.Contracts;
    using GameFifteen.UI.Console;
    using GameFifteen.UI.Console.ConsoleUserInterfaceIOHandlers;
    using GameFifteen.UI.Console.GameInitializer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Class test GameInitializerTests.
    /// </summary>
    [TestClass]
    public class GameInitializerTests
    {
        /// <summary>
        /// Test that test method initialize returns a classic game.
        /// </summary>
        [TestMethod]
        public void TestMethodInitializeReturnsAClassicGame()
        {
            var mockPrinter = new Mock<IPrinter>();
            var mockReader = new Mock<IReader>();

            const string TileType = "Number";
            const string FramePattern = "Classic";
            const string Rows = "4";
            const string Cols = "4";
            const string MoverType = "Classic";

            mockReader.SetupSequence(r => r.ReadLine())
                .Returns(TileType)
                .Returns(FramePattern)
                .Returns(Rows)
                .Returns(Cols)
                .Returns(MoverType);

            var gameInitializator = new GameInitializer(mockPrinter.Object, mockReader.Object);
            var game = gameInitializator.Initialize();

            Assert.IsInstanceOfType(game, typeof(IGame));
        }

        /// <summary>
        /// Test that test method initialize returns a custom game.
        /// </summary>
        [TestMethod]
        public void TestMethodInitializeReturnsACustomGame()
        {
            var mockPrinter = new Mock<IPrinter>();
            var mockReader = new Mock<IReader>();

            const string TileType = "Letter";
            const string FramePattern = "Column";
            const string Rows = "2";
            const string Cols = "2";
            const string MoverType = "RowCol";

            mockReader.SetupSequence(r => r.ReadLine())
                .Returns(TileType)
                .Returns(FramePattern)
                .Returns(Rows)
                .Returns(Cols)
                .Returns(MoverType);

            var gameInitializator = new GameInitializer(mockPrinter.Object, mockReader.Object);
            var game = gameInitializator.Initialize();

            Assert.IsInstanceOfType(game, typeof(IGame));
        }
    }
}
