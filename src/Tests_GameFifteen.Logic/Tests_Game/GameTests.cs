// <copyright file="GameTests.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// GameTests class.
// </summary>
// <author>GameFifteen2Team</author>

namespace Tests_GameFifteen.Logic.Tests_Game
{
    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Games;
    using GameFifteen.Logic.Movers.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    /// <summary>
    /// GameTests test class test Game class. Uses mocking.
    /// </summary>
    [TestClass]
    public class GameTests
    {
        /// <summary>
        /// The method tests if to different frame's prototype instances are equal.
        /// </summary>
        [TestMethod]
        public void TestGameSetsFramePrototypeWithDifferentInstanceOfFrameButEqualToIt()
        {
            var mockFrameClone = new Mock<IFrame>();
            var mockFrame = new Mock<IFrame>();

            mockFrame.Setup(f => f.Clone()).Returns(mockFrameClone.Object);

            mockFrame.Setup(f => f.Equals(It.IsAny<IFrame>())).Returns(true);

            var mockMover = new Mock<IMover>();

            var game = new Game(mockFrame.Object, mockMover.Object);

            Assert.AreNotSame(game.Frame, game.FramePrototype);
            Assert.IsTrue(game.Frame.Equals(game.FramePrototype));
        }

        /// <summary>
        /// The method tests if the game is solved when the initial state of the frame is not shuffled.
        /// </summary>
        [TestMethod]
        public void TestGameIsSolvedWhenCreatedAndNotShuffledYet()
        {
            var mockFrameClone = new Mock<IFrame>();
            var mockFrame = new Mock<IFrame>();

            mockFrame.Setup(f => f.Clone()).Returns(mockFrameClone.Object);

            mockFrame.Setup(f => f.Equals(It.IsAny<IFrame>())).Returns(true);

            var mockMover = new Mock<IMover>();

            var game = new Game(mockFrame.Object, mockMover.Object);

            Assert.IsTrue(game.IsSolved);
        }

        /// <summary>
        /// The method tests if game Mover Moves its frame.
        /// </summary>
        [TestMethod]
        public void TestGameCallsMoverMovePasssingItItsFrame()
        {
            var mockFrame = new Mock<IFrame>();
            var mockMover = new Mock<IMover>();

            var game = new Game(mockFrame.Object, mockMover.Object);
            game.Move(string.Empty);
            mockMover.Verify(m => m.Move(It.IsAny<string>(), mockFrame.Object), Times.Once);
        }

        /// <summary>
        /// The method tests if game Mover shuffles its frame.
        /// </summary>
        [TestMethod]
        public void TestGameCallsMoverShufflePassingItItsFrame()
        {
            var mockFrameClone = new Mock<IFrame>();
            var mockFrame = new Mock<IFrame>();

            mockFrame.Setup(f => f.Clone()).Returns(mockFrameClone.Object);

            mockFrame.Setup(f => f.Equals(It.IsAny<IFrame>())).Returns(false);

            var mockMover = new Mock<IMover>();

            var game = new Game(mockFrame.Object, mockMover.Object);
            game.Shuffle();

            mockMover.Verify(m => m.Shuffle(mockFrame.Object), Times.Once, "Game is not calling mover.Shuffle");
            Assert.IsFalse(game.Frame.Equals(game.FramePrototype), "The frame is not shuffled");
        }
    }
}
