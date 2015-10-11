// <copyright file="ProxyFrame.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ProxyFrame class.
// </summary>
// <author>GameFifteen2Team</author>

namespace Tests_GameFifteen.Logic.Tests_Frames
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using GameFifteen.Logic.Frames.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// ProxyFrame tests class test ProxyFrame class.
    /// </summary>
    [TestClass]
    public class ProxyFrame
    {
        /// <summary>
        /// The test NOT to catch exception when getting hash code of ProxyFrame.
        /// </summary>
        [TestMethod]
        public void ExpectDoNotCatchExaptionsTestGetHeshCodeMetothdInProxyFrame()
        {
            var proxy = new ProxyFrame();
            var hash = proxy.GetHashCode();
        }

        /// <summary>
        /// The test Equals method of ProxyFrame().
        /// </summary>
        [TestMethod]
        public void ExpectDoNotCatchExaptionsTestEqualsMethodtInProxyFrame()
        {
            var proxyOne = new ProxyFrame();
            var proxyTwo = proxyOne;
            var result = proxyOne.Equals(proxyTwo);
            Assert.IsTrue(result);
        }
    }
}
