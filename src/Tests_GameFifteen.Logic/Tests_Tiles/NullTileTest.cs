// <copyright file="NullTileTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// NullTileTest class.
// </summary>
// <author>GameFifteen2Team</author>

namespace Tests_GameFifteen.Logic.Tests_Tiles
{
    using GameFifteen.Logic.Tiles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// NullTileTest test class test NullTile class.
    /// </summary>
    [TestClass]
    public class NullTileTest
    {
        /// <summary>
        /// The method test creation of null tile.
        /// </summary>
        [TestMethod]
        public void TestCreationsOfNullTile()
        {
            var tileFactory = new NumberTileFactory();
            var nullTile = tileFactory.CreateNullTile();
            const string ExpectLabel = "";
            string actualLabel = nullTile.Label;

            Assert.AreEqual(ExpectLabel, actualLabel);
        }

        /// <summary>
        /// The method test label null tile.
        /// </summary>
        [TestMethod]
        public void TestLabelOfNullTile()
        {
            var numberTile = new NullTile(0);
            const string ExpectLabel = "";
            string actualLabel = numberTile.Label;

            Assert.AreEqual(ExpectLabel, actualLabel);
        }
    }
}
