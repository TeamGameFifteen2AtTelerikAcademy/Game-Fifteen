namespace Tests_GameFifteen.Logic.Tests_Game
{
    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Games;
    using GameFifteen.Logic.Movers.Contracts;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class GameTests
    {
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

        [TestMethod]
        public void TestGameCallsMoverMovePasssingItItsFrame()
        {
            var mockFrame = new Mock<IFrame>();
            var mockMover = new Mock<IMover>();

            var game = new Game(mockFrame.Object, mockMover.Object);
            game.Move(string.Empty);
            mockMover.Verify(m => m.Move(It.IsAny<string>(), mockFrame.Object), Times.Once);
        }

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
