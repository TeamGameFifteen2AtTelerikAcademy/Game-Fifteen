// <copyright file="FrameDirectorTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// FrameDirectorTest class.
// </summary>
// <author>GameFifteen2Team</author>

namespace Tests_GameFifteen.Logic.Tests_Frames
{ 
    using GameFifteen.Logic.Frames;
    using GameFifteen.Logic.Frames.Contracts;
    using GameFifteen.Logic.Tiles;
    using GameFifteen.Logic.Tiles.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// ClassicPatternFrameBuilderTest class tests ClassicPatternFrameBuilder class.
    /// </summary>
    [TestClass]
    public class FrameDirectorTest
    {
        /// <summary>
        /// The method test GetFrame method of ColumnsPatternFrameBuilder returns correct build frame.
        /// </summary>
        [TestMethod]
        public void TestThatGetFrameInFrameBIlderReturnedValueWithColumnsPatternFrameBuilderr()
        {
            TileFactory tileFactory = new LetterTileFactory();
            FrameBuilder frameBuilder = new ColumnsPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var actualFrame = frameDirector.ConstructFrame(2, 2);
            Assert.IsNotNull(actualFrame);
        }

        /// <summary>
        /// The method test GetFrame method of ColumnsPatternFrameBuilder returns correct build frame.
        /// </summary>
        [TestMethod]
        public void TestThatGetFrameInFrameBIlderCorectFrameWithColumnsPatternFrameBuilder()
        {
            TileFactory tileFactory = new LetterTileFactory();
            FrameBuilder frameBuilder = new ColumnsPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var actualBuilder = frameDirector.ConstructFrame(2, 2);
            Assert.IsInstanceOfType(actualBuilder, typeof(IFrame));
        }

        /// <summary>
        /// The method test GetFrame method of ClassicPatternFrameBuilder returns correct build frame.
        /// </summary>
        [TestMethod]
        public void TestThatGetFrameInFrameBIlderReturnedValueWithClassicPatternFrameBuilder()
        {
            TileFactory tileFactory = new LetterTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var actualFrame = frameDirector.ConstructFrame(0, 0);
            Assert.IsNotNull(actualFrame);
        }

        /// <summary>
        /// The method test GetFrame method of ClassicPatternFrameBuilder returns correct build frame.
        /// </summary>
        [TestMethod]
        public void TestThatGetFrameInFrameBIlderCorectFrameWithClassicPatternFrameBuilder()
        {
            TileFactory tileFactory = new LetterTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var actualFrame = frameDirector.ConstructFrame(2, 2);
            Assert.IsInstanceOfType(actualFrame, typeof(IFrame));
        }

        /// <summary>
        /// The method test GetFrame method of ClassicPatternFrameBuilder returns correct build frame.
        /// </summary>
        [TestMethod]
        public void TestThatGetFrameInFrameBIlderCorectFrameWithClassicPatternFrameBuilderGreatFrameDimensionMin()
        {
            TileFactory tileFactory = new LetterTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var actualFrame = frameDirector.ConstructFrame(5, 5);
            Assert.IsInstanceOfType(actualFrame, typeof(IFrame));
        }

        /// <summary>
        /// The method test Clone method of ClassicPatternFrameBuilder returns correct deep copy of the frame..
        /// </summary>
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
