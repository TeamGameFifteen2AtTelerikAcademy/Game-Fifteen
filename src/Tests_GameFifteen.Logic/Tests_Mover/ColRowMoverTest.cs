// <copyright file="ColRowMoverTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ColRowMoverTest class.
// </summary>
// <author>GameFifteen2Team</author>

namespace Tests_GameFifteen.Logic.Tests_Mover
{
    using GameFifteen.Logic.Frames;
    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Movers;
    using GameFifteen.Logic.Tiles;
    using GameFifteen.Logic.Tiles.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// ColRowMoverTest test class tests RowColMover class.
    /// </summary>
    [TestClass]
    public class ColRowMoverTest
    {
        /// <summary>
        /// The method tests if Mover moves a tile when it is possible.
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

        /// <summary>
        /// The method tests if Mover NOT  moves a tile when it is NOT possible.
        /// </summary>
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

        /// <summary>
        /// The method tests if Mover NOT moves an empty string tile.
        /// </summary>
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

        /// <summary>
        /// The method tests if Mover NOT moves an null tile.
        /// </summary>
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

        /// <summary>
        /// The method tests if Mover moves a all tiles by column when it is possible.
        /// </summary>
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

        /// <summary>
        /// The method tests if Mover shuffles a tiles by column when it is possible.
        /// </summary>
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

        /// <summary>
        /// The method tests if Mover moves a all tiles left by row when it is possible.
        /// </summary>
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

        /// <summary>
        /// The method tests if Mover moves a all tiles right by row when it is possible.
        /// </summary>
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

        /// <summary>
        /// The method tests if Mover moves a all tiles down by column when it is possible.
        /// </summary>
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

        /// <summary>
        /// The method tests if Mover moves a all tiles up by column when it is possible.
        /// </summary>
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
