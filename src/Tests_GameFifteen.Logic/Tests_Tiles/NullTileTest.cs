using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen.Logic.Tiles;
using GameFifteen.Logic.Tiles.Contracts;

namespace Tests_GameFifteen.Logic.Tests_Tiles
{
    /// <summary>
    /// Summary description for NullTileTest
    /// </summary>
    [TestClass]
    public class NullTileTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>

        [TestMethod]
        public void TestCreationsOfNullTile()
        {
            var tileFactory = new NumberTileFactory();
            var nullTile = tileFactory.CreateNullTile();
            const string expectLabel = "";
            string actualLabel = nullTile.Label;

            Assert.AreEqual(expectLabel, actualLabel);
        }

        [TestMethod]
        public void TestLabelOfNullTile()
        {
            var numberTile = new NullTile(0);
            const string expectLabel = "";
            string actualLabel = numberTile.Label;

            Assert.AreEqual(expectLabel, actualLabel);
        }
    }
}
