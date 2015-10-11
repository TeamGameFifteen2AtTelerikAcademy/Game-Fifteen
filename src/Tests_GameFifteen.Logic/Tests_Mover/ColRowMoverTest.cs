using System;

namespace Tests_GameFifteen.Logic.Tests_Mover
{
    using GameFifteen.Logic.Frames;
    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Movers;
    using GameFifteen.Logic.Tiles;
    using GameFifteen.Logic.Tiles.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for ColRowMoverTest
    /// </summary>
    [TestClass]
    public class ColRowMoverTest
    {
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        [TestMethod]
        public void TestMoverIsMovingATileWhichCanBeMovedRowColMover()
        {
            var mover = new RowColMover();
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var initialFrame = frameDirector.ConstructFrame(4, 4);
            var actualFrame = initialFrame.Clone();
            bool result = mover.Move("15", actualFrame);
            Assert.IsTrue(result, "Mover method should return true when the tile can be moved");
            Assert.AreNotEqual(initialFrame, actualFrame, "The frame should be changed when the mover moves the tile");
        }

        [TestMethod]
        public void TestMoverNotMovingATileWhichCanNotBeMovedRowColMover()
        {
            var mover = new RowColMover();
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var initialFrame = frameDirector.ConstructFrame(4, 4);
            var actualFrame = initialFrame.Clone();
            bool result = mover.Move("1", actualFrame);
            Assert.IsFalse(result, "Mover method should return false when the tile can not be moved");
            Assert.AreEqual(initialFrame, actualFrame, "The frame should not be changed");
        }

        [TestMethod]
        public void TestMoverTryMovingAEmptyStringTileAndTileNotBeMovedRowColMover()
        {
            var mover = new RowColMover();
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var initialFrame = frameDirector.ConstructFrame(4, 4);
            var actualFrame = initialFrame.Clone();
            bool result = mover.Move(string.Empty, actualFrame);
            Assert.IsFalse(result, "Mover method should return false when the tile can not be moved");
            Assert.AreEqual(initialFrame, actualFrame, "The frame should not be changed");
        }

        [TestMethod]
        public void TestMoverTryMovingANullTileAndTileNotBeMovedRowColMover()
        {
            var mover = new RowColMover();
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var initialFrame = frameDirector.ConstructFrame(4, 4);
            var actualFrame = initialFrame.Clone();
            bool result = mover.Move(null, actualFrame);
            Assert.IsFalse(result, "Mover method should return false when the tile can not be moved");
            Assert.AreEqual(initialFrame, actualFrame, "The frame should not be changed");
        }

        [TestMethod]
        public void TestMoverIsMovingATileWhichCanBeMovedByColumnRowColMover()
        {
            var mover = new RowColMover();
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var initialFrame = frameDirector.ConstructFrame(4, 4);
            var actualFrame = initialFrame.Clone();
            bool result = mover.Move("12", actualFrame);
            Assert.IsTrue(result, "Mover method should return true when the tile can be moved");
            Assert.AreNotEqual(initialFrame, actualFrame, "The frame should be changed when the mover moves the tile");
        }

        [TestMethod]
        public void TestShuffleIsMovingATileWhichCanBeMovedByColumnRowColMover()
        {
            var mover = new RowColMover();
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var initialFrame = frameDirector.ConstructFrame(4, 4);
            var actualFrame = initialFrame.Clone();
            mover.Shuffle(actualFrame);
            Assert.AreNotEqual(initialFrame, actualFrame, "The frame should be changed when shuffled");
        }

        [TestMethod]
        public void TestMoverIsMovingATileWhichCanBeMovedByLeftAllRowRowColMover()
        {
            var mover = new RowColMover();
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var initialFrame = frameDirector.ConstructFrame(4, 4);
            var actualFrame = initialFrame.Clone();
            bool moveLeft = mover.Move("13", actualFrame);
            Assert.IsTrue(moveLeft, "Mover method should return true when the tile can be moved");
            Assert.AreNotEqual(initialFrame, actualFrame, "The frame should be changed when the mover moves the tile");
        }

        [TestMethod]
        public void TestMoverIsMovingATileWhichCanBeMovedByRightAllRowRowColMover()
        {
            var mover = new RowColMover();
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var initialFrame = frameDirector.ConstructFrame(4, 4);
            var actualFrame = initialFrame.Clone();
            bool moveLeft = mover.Move("13", actualFrame);
            bool moveRight = mover.Move("14", actualFrame);
            Assert.IsTrue(moveRight, "Mover method should return true when the tile can be moved");
            Assert.AreNotEqual(initialFrame, actualFrame, "The frame should be changed when the mover moves the tile");
        }

        [TestMethod]
        public void TestMoverIsMovingATileWhichCanBeMovedDownAllColumnRowColMover()
        {
            var mover = new RowColMover();
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var initialFrame = frameDirector.ConstructFrame(4, 4);
            var actualFrame = initialFrame.Clone();
            bool moveDown = mover.Move("4", actualFrame);
            Assert.IsTrue(moveDown, "Mover method should return true when the tile can be moved");
            Assert.AreNotEqual(initialFrame, actualFrame, "The frame should be changed when the mover moves the tile");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
        "The frame cannot be shuffled because it does not have a null tile.")]
        public void ExpectExseptionsShuffleWithTileWhichCanBeMovedRowColMover()
        {
            var mover = new RowColMover();
            IFrame initialFrame = new Frame(new ITile[,] { { new NumberTile(1) } });
            var actualFrame = initialFrame.Clone();
            mover.Shuffle(actualFrame);

        }

        [TestMethod]
        public void TestMoverNotMovingATileWhenInFrameHaveNotNullTileRowColMover()
        {
            var mover = new RowColMover();
            IFrame initialFrame = new Frame(new ITile[,] { { new NumberTile(1) } });
            var actualFrame = initialFrame.Clone();
            bool moveDown = mover.Move("1", actualFrame);
            Assert.IsFalse(moveDown, "Mover method should return false when the tile can not be moved");
            Assert.AreEqual(initialFrame, actualFrame, "The frame should not be changed");
        }
    }
}
