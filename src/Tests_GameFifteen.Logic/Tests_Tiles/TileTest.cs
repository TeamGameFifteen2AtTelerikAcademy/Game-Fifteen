using System;
using System.Text;
using System.Collections.Generic;
using GameFifteen.Logic.Tiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_GameFifteen.Logic.Tests_Tiles
{
    /// <summary>
    /// Summary description for TileTest
    /// </summary>
    [TestClass]
    public class TileTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        
        [TestMethod]
        public void ExpectTrueEqualsMethodWhithTwoITileObjeckTest()
        {
            var numberTileFirst = new NumberTile(1);
            var numberTileSecond = new NumberTile(1);
            bool result = numberTileFirst.Equals(numberTileSecond);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ExpectTrueEqualsMethodWhithOneITileObjeckAndObjecktTest()
        {
            var numberTileFirst = new NumberTile(1);
            var numberTileSecond = new NumberTile(1);
            bool result = numberTileFirst.Equals(numberTileSecond as Object);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void ExpectFalseEqualsMethodWhithNullObjeckTest()
        {
            var numberTileFirst = new NumberTile(1);
            NumberTile numberTileSecond = null;
            bool result = numberTileFirst.Equals(numberTileSecond);
            Assert.IsFalse(result);

        }
    }
}
