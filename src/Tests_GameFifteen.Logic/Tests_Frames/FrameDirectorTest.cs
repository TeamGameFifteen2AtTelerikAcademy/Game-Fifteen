using System;
using System.Text;
using System.Collections.Generic;
using GameFifteen.Logic.Frames;
using GameFifteen.Logic.Frames.Contracts;
using GameFifteen.Logic.Tiles;
using GameFifteen.Logic.Tiles.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_GameFifteen.Logic.Tests_Frames
{
    /// <summary>
    /// Summary description for ClassicPatternFrameBuilderTest
    /// </summary>
    [TestClass]
    public class FrameDirectorTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
       
        [TestMethod]
        public void TestThatGetFrameInFrameBIlderReturnedValueWithColumnsPatternFrameBuilderr()
        {
           TileFactory tileFactory = new LetterTileFactory();
           FrameBuilder frameBuilder = new ColumnsPatternFrameBuilder(tileFactory);
           var frameDirector = new FrameDirector(frameBuilder);
           var actualFrame = frameDirector.ConstructFrame(2, 2);
           Assert.IsNotNull(actualFrame);
        }

        [TestMethod]
        public void TestThatGetFrameInFrameBIlderCorectFrameWithColumnsPatternFrameBuilder()
        {
            TileFactory tileFactory = new LetterTileFactory();
            FrameBuilder frameBuilder = new ColumnsPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var actualBuilder = frameDirector.ConstructFrame(2, 2);
            Assert.IsInstanceOfType(actualBuilder, typeof(IFrame));
        }

        [TestMethod]
        public void TestThatGetFrameInFrameBIlderReturnedValueWithClassicPatternFrameBuilder()
        {
            TileFactory tileFactory = new LetterTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var actualFrame = frameDirector.ConstructFrame(0, 0);
            Assert.IsNotNull(actualFrame);
        }

        [TestMethod]
        public void TestThatGetFrameInFrameBIlderCorectFrameWithClassicPatternFrameBuilder()
        {
            TileFactory tileFactory = new LetterTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var actualFrame = frameDirector.ConstructFrame(2, 2);
            Assert.IsInstanceOfType(actualFrame, typeof(IFrame));
        }

        [TestMethod]
        public void TestThatGetFrameInFrameBIlderCorectFrameWithClassicPatternFrameBuilderGreatFrameDimensionMin()
        {
            TileFactory tileFactory = new LetterTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var actualFrame = frameDirector.ConstructFrame(5, 5);
            Assert.IsInstanceOfType(actualFrame, typeof(IFrame));
        }

        [TestMethod]
        public void TestThatGetFrameInFrameBIlderCorectFrameWithClassicPatternFrameBuilderClone()
        {
            TileFactory tileFactory = new LetterTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var expectetFrame = frameDirector.ConstructFrame(5, 5);
            var actualsFrame = expectetFrame.Clone();
            Assert.AreEqual(expectetFrame, actualsFrame);
        }
    }
}
