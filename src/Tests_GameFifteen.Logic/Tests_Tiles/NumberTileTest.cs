// <copyright file="NumberTileTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// NumberTileTest class.
// </summary>
// <author>GameFifteen2Team</author>

namespace Tests_GameFifteen.Logic.Tests_Tiles
{
    using GameFifteen.Logic.Tiles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// NumberTileTest test class tests NumberTile class.
    /// </summary>
    [TestClass]
    public class NumberTileTest
    {
        /// <summary>
        /// The method tests the label of the tile.
        /// </summary>
        [TestMethod]
        public void TestLabelOfNumberTile()
        {
            var numberTile = new NumberTile(2);
            const string ExpectLabel = "2";
            string actualLabel = numberTile.Label;

            Assert.AreEqual(ExpectLabel, actualLabel);
        }
    }
}
