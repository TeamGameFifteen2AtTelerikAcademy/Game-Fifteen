// <copyright file="FrameTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// FrameTest class.
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
    /// FrameTest class tests Frame class.
    /// </summary>
    [TestClass]
    public class FrameTest
    {
        /// <summary>
        /// The method tests if to different instances of frames are equal depending on their content. 
        /// Test Equals method overriding.
        /// </summary>
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

        /// <summary>
        /// The method tests if null and not null frame are NOT equal. 
        /// Test Equals method overriding.
        /// </summary>
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

        /// <summary>
        /// The method tests if  to different instances of frames are  NOT equal depending on their content.
        /// Test Equals method overriding.
        /// </summary>
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

        /// <summary>
        /// The method tests if  to different instances of frames are  NOT equal depending on their content.
        /// Test Equals method overriding.
        /// </summary>
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
