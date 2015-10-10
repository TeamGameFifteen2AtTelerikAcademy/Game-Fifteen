﻿using System;
using System.Text;
using System.Collections.Generic;
using GameFifteen.Logic.Frames.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_GameFifteen.Logic.Tests_Frames
{
    /// <summary>
    /// Summary description for ProxyFrame
    /// </summary>
    [TestClass]
    public class ProxyFrame
    {
        
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
       
        [TestMethod]
        public void ExpectDoNotCatchExaptionsTestGetHeshCodeMetothdInProxyFrame()
        {
          var proxy = new ProxyFrame();
          var hash = proxy.GetHashCode();
            
        }

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
