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
    /// Summary description for Mover
    /// </summary>
    [TestClass]
    public class ClassicMoverTest
    {
       
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
       
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

        [TestMethod]
        public void TestMoverTryMovingAEmptyStringTileAndTileNotBeMoved()
        {
            var mover = new ClassicMover();
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var initialFrame = frameDirector.ConstructFrame(4, 4);
            var actualFrame = initialFrame.Clone();
            bool result = mover.Move("", actualFrame);
            Assert.IsFalse(result, "Mover method should return false when the tile can not be moved");
            Assert.AreEqual(initialFrame, actualFrame, "The frame should not be changed");
        }

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

        [TestMethod]
         [ExpectedException(typeof(ArgumentException),
         "The frame cannot be shuffled because it does not have a null tile.")]
        public void ExpectExseptionsShuffleWithTileWhichCanBeMoved()
        {
            var mover = new ClassicMover();
            IFrame initialFrame = new Frame(new ITile[,] { { new NumberTile(1) } });
            var actualFrame = initialFrame.Clone();
            mover.Shuffle(actualFrame);
            
        }

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
