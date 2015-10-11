using GameFifteen.Logic.Frames;
using GameFifteen.Logic.Tiles;
using GameFifteen.Logic.Tiles.Contracts;

namespace Tests_GameFifteen.Logic.Tests_Frames
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GameFifteen.Logic.Frames.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for ProxyFrame
    /// </summary>
    [TestClass]
    public class ProxyFrameTest
    {
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
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
