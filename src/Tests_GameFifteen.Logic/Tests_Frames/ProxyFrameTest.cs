using System;
using System.Text;
using System.Collections.Generic;
using GameFifteen.Logic.Common;
using GameFifteen.Logic.Frames;
using GameFifteen.Logic.Frames.Contracts;
using GameFifteen.Logic.Tiles;
using GameFifteen.Logic.Tiles.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Tests_GameFifteen.Logic.Tests_Frames
{
    /// <summary>
    /// Summary description for ProxyFrame
    /// </summary>
    [TestClass]
    public class ProxyFrameTest
    {
        
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
       
        [TestMethod]
        public void ExpectDoNotCatchExaptionsTestGetHeshCodeMetothdInProxyFrame()
        {
            TileFactory tileFactoryFirst = new NumberTileFactory();
            FrameBuilder frameBuilderFirst = new ClassicPatternFrameBuilder(tileFactoryFirst);
            var frameDirectorFirst = new FrameDirector(frameBuilderFirst);
            var expectetFrameFirst = frameDirectorFirst.ConstructFrame(5, 5);
            var proxyFrame = new ProxyFrame(expectetFrameFirst);
            var hash = proxyFrame.GetHashCode();
            
        }

        [TestMethod]
        public void ExpectDoNotCatchExaptionsTestEqualsMethodtInProxyFrame()
        {
            var proxyOne = new ProxyFrameTest();
            var proxyTwo = proxyOne;
            var result = proxyOne.Equals(proxyTwo);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void TestToStringMetothdInProxyFrameDoNotHandleExeptions()
        {
            TileFactory tileFactoryFirst = new NumberTileFactory();
            FrameBuilder frameBuilderFirst = new ClassicPatternFrameBuilder(tileFactoryFirst);
            var frameDirectorFirst = new FrameDirector(frameBuilderFirst);
            var expectetFrameFirst = frameDirectorFirst.ConstructFrame(5, 5);
            var proxyFrame = new ProxyFrame(expectetFrameFirst);
            string expectedresult ="-----------------\r\n|  1  2  3  4  5|\r\n|  6  7  8  9 10|\r\n| 11 12 13 14 15|\r\n| 16 17 18 19 20|\r\n| 21 22 23 24   |\r\n-----------------";
            string actualsresult = proxyFrame.ToString();
            Assert.AreEqual(expectedresult, actualsresult);

        }
    }
}
