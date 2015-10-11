// <copyright file="ProxyFrameTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ProxyFrameTest class.
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
    /// ProxyFrameTest test class tests ProxyFrame.
    /// </summary>
    [TestClass]
    public class ProxyFrameTest
    {
        /// <summary>
        /// The method tests NOT to catch exception when getting hash code of ProxyFrame.     
        /// </summary>
        [TestMethod]
        public void ExpectDoNotCatchExaptionsTestGetHeshCodeMetothdInProxyFrame()
        {
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var expectetFrame = frameDirector.ConstructFrame(5, 5);
            var proxyFrame = new ProxyFrame(expectetFrame);
            var hash = proxyFrame.GetHashCode();
        }

        /// <summary>
        /// The method tests NOT to catch exception when comparing ProxyFrames with Equals method.     
        /// </summary>
        [TestMethod]
        public void ExpectDoNotCatchExaptionsTestEqualsMethodtInProxyFrame()
        {
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var expectetFrame = frameDirector.ConstructFrame(5, 5);
            var proxyFrame = new ProxyFrame(expectetFrame);
            var proxyOne = new ProxyFrame(proxyFrame);
            var proxyTwo = proxyOne;
            var result = proxyOne.Equals(proxyTwo);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The method tests NOT to catch exception when using ToString method.     
        /// </summary>
        [TestMethod]
        public void TestToStringMetothdInProxyFrameDoNotHandleExeptions()
        {
            TileFactory tileFactory = new NumberTileFactory();
            FrameBuilder frameBuilder = new ClassicPatternFrameBuilder(tileFactory);
            var frameDirector = new FrameDirector(frameBuilder);
            var expectetFrame = frameDirector.ConstructFrame(5, 5);
            var proxyFrame = new ProxyFrame(expectetFrame);
            string expectedresult = "-----------------\r\n|  1  2  3  4  5|\r\n|  6  7  8  9 10|\r\n| 11 12 13 14 15|\r\n| 16 17 18 19 20|\r\n| 21 22 23 24   |\r\n-----------------";
            string actualsresult = proxyFrame.ToString();
            Assert.AreEqual(expectedresult, actualsresult);
        }
    }
}