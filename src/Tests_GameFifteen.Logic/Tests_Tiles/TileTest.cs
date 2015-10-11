// <copyright file="TileTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// TileTest class.
// </summary>
// <author>GameFifteen2Team</author>

namespace Tests_GameFifteen.Logic.Tests_Tiles
{
    using GameFifteen.Logic.Tiles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// TileTest test class test Tile class.
    /// </summary>
    [TestClass]
    public class TileTest
    {
        /// <summary>
        /// The method tests Equals method to return TRUE when two different instances of tiles with equal Id's are compared.
        /// </summary>
        [TestMethod]
        public void ExpectTrueEqualsMethodWhithTwoITileObjeckTest()
        {
            var numberTileFirst = new NumberTile(1);
            var numberTileSecond = new NumberTile(1);
            bool result = numberTileFirst.Equals(numberTileSecond);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The method tests Equals method to return TRUE when two different instances of tiles with equal Id's are compared and one is used as object.
        /// </summary>
        [TestMethod]
        public void ExpectTrueEqualsMethodWhithOneITileObjeckAndObjecktTest()
        {
            var numberTileFirst = new NumberTile(1);
            var numberTileSecond = new NumberTile(1);
            bool result = numberTileFirst.Equals(numberTileSecond as object);
            Assert.IsTrue(result);
        }

        /// <summary>
        /// The method tests Equals method to return FALSE when two different instances tile compared is compared with null object..
        /// </summary>
        [TestMethod]
        public void ExpectFalseEqualsMethodWhithNullObjeckTest()
        {
            var numberTileFirst = new NumberTile(1);
            NumberTile numberTileSecond = null;
            bool result = numberTileFirst.Equals(numberTileSecond);
            Assert.IsFalse(result);
        }

        /// <summary>
        /// The method tests GetHashCode.
        /// </summary>
        [TestMethod]
        public void TestGetHashCodeMethodInTile()
        {
            var numberTile = new NumberTile(1);
            numberTile.GetHashCode();
        }

        /// <summary>
        /// The method tests ToString.
        /// </summary>
        [TestMethod]
        public void TestToStringMethodInTile()
        {
            var numberTile = new NumberTile(1);
            numberTile.ToString();
        }
    }
}
