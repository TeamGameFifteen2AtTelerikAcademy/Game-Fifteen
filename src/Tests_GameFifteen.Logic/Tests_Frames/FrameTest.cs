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
    /// Summary description for FrameTest
    /// </summary>
    [TestClass]
    public class FrameTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>

        [TestMethod]
        public void ExpectTrueEqualsMethodWhithTwoIframeTest()
        {
            TileFactory tileFactoryFirst = new NumberTileFactory();
            TileFactory tileFactorySecond = new NumberTileFactory();
            FrameBuilder frameBuilderFirst = new ClassicPatternFrameBuilder(tileFactoryFirst);
            FrameBuilder frameBuilderSecond = new ClassicPatternFrameBuilder(tileFactorySecond);
            var frameDirectorFirst = new FrameDirector(frameBuilderFirst);
            var frameDirectorSecond = new FrameDirector(frameBuilderSecond);
            var expectetFrameFirst = frameDirectorFirst.ConstructFrame(5, 5);
            var expectetFrameSecond = frameDirectorSecond.ConstructFrame(5, 5);
            bool result = expectetFrameFirst.Equals(expectetFrameSecond);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ExpectTrueEqualsMethodWhithNullIframeTest()
        {
            TileFactory tileFactoryFirst = new NumberTileFactory();
            FrameBuilder frameBuilderFirst = new ClassicPatternFrameBuilder(tileFactoryFirst);
            var frameDirectorFirst = new FrameDirector(frameBuilderFirst);
            var expectetFrameFirst = frameDirectorFirst.ConstructFrame(5, 5);
            IFrame expectetFrameSecond = null;
            bool result = expectetFrameFirst.Equals(expectetFrameSecond);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void ExpectFalseEqualsMethodWhithDiferentIframeWithDiferentColTest()
        {
            TileFactory tileFactoryFirst = new NumberTileFactory();
            TileFactory tileFactorySecond = new NumberTileFactory();
            FrameBuilder frameBuilderFirst = new ClassicPatternFrameBuilder(tileFactoryFirst);
            FrameBuilder frameBuilderSecond = new ColumnsPatternFrameBuilder(tileFactorySecond);
            var frameDirectorFirst = new FrameDirector(frameBuilderFirst);
            var frameDirectorSecond = new FrameDirector(frameBuilderSecond);
            var expectetFrameFirst = frameDirectorFirst.ConstructFrame(5, 5);
            var expectetFrameSecond = frameDirectorSecond.ConstructFrame(5, 5);
            bool result = expectetFrameFirst.Equals(expectetFrameSecond);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void ExpectFalseEqualsMethodWhithDiferentIframeWithDiferentSizeOfColumnsTest()
        {
            TileFactory tileFactoryFirst = new NumberTileFactory();
            TileFactory tileFactorySecond = new NumberTileFactory();
            FrameBuilder frameBuilderFirst = new ClassicPatternFrameBuilder(tileFactoryFirst);
            FrameBuilder frameBuilderSecond = new ColumnsPatternFrameBuilder(tileFactorySecond);
            var frameDirectorFirst = new FrameDirector(frameBuilderFirst);
            var frameDirectorSecond = new FrameDirector(frameBuilderSecond);
            var expectetFrameFirst = frameDirectorFirst.ConstructFrame(5, 5);
            var expectetFrameSecond = frameDirectorSecond.ConstructFrame(6, 6);
            bool result = expectetFrameFirst.Equals(expectetFrameSecond);
            Assert.IsFalse(result);

        }

    }
}
