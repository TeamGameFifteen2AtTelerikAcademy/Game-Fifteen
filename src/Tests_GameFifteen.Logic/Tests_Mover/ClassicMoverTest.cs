// <copyright file="ClassicMoverTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ClassicMoverTest class.
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
    /// ClassicMoverTest test class test ClassicMover class.
    /// </summary>
    [TestClass]
    public class ClassicMoverTest
    {
        /// <summary>
        /// The method tests if Mover moves a tile when it is possible.
        /// </summary>
        [TestMethod]
        public void TestMoverIsMovingATileWhichCanBeMoved()
        {
            var mover = new ClassicMover();
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
        public void TestMoverNotMovingATileWhichCanNotBeMoved()
        {
            var mover = new ClassicMover();
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var initialFrame = frameDirector.ConstructFrame(4, 4);
            var actualFrame = initialFrame.Clone();
            bool result = mover.Move("14", actualFrame);
            Assert.IsFalse(result, "Mover method should return false when the tile can not be moved");
            Assert.AreEqual(initialFrame, actualFrame, "The frame should not be changed");
        }

        /// <summary>
        /// The method tests if Mover NOT moves an empty string tile.
        /// </summary>
        [TestMethod]
        public void TestMoverTryMovingAEmptyStringTileAndTileNotBeMoved()
        {
            var mover = new ClassicMover();
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
        public void TestMoverTryMovingANullTileAndTileNotBeMoved()
        {
            var mover = new ClassicMover();
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
        /// The method tests if Mover moves a tile by column when it is possible.
        /// </summary>
        [TestMethod]
        public void TestMoverIsMovingATileWhichCanBeMovedByColumn()
        {
            var mover = new ClassicMover();
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
        /// The method tests if Mover shuffles a tile by column when it is possible.
        /// </summary>
        [TestMethod]
        public void TestShuffleIsMovingATileWhichCanBeMovedByColumn()
        {
            var mover = new ClassicMover();
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var initialFrame = frameDirector.ConstructFrame(4, 4);
            var actualFrame = initialFrame.Clone();
            mover.Shuffle(actualFrame);
            Assert.AreNotEqual(initialFrame, actualFrame, "The frame should be changed when shuffled");
        }

        /// <summary>
        /// The method tests if Mover NOT moving a tile when in frame have not null tile.
        /// </summary>
        [TestMethod]
        public void TestMoverNotMovingATileWhenInFrameHaveNotNullTileClassicMover()
        {
            var mover = new ClassicMover();
            IFrame initialFrame = new Frame(new ITile[,] { { new NumberTile(1) } });
            var actualFrame = initialFrame.Clone();
            bool moveDown = mover.Move("4", actualFrame);
            Assert.IsFalse(moveDown, "Mover method should return false when the tile can not be moved");
            Assert.AreEqual(initialFrame, actualFrame, "The frame should not be changed");
        }
    }
}
