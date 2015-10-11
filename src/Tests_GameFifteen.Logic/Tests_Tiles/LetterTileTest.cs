// <copyright file="LetterTileTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// LetterTileTest class.
// </summary>
// <author>GameFifteen2Team</author>

namespace Tests_GameFifteen.Logic.Tests_Tiles
{
    using GameFifteen.Logic.Tiles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// LetterTileTest test class tests LetterTile class.
    /// </summary>
    [TestClass]
    public class LetterTileTest
    {
        /// <summary>
        /// The method tests the label of the tile.
        /// </summary>
        [TestMethod]
        public void TestLabelOfLetterTile()
        {
            var numberTile = new LetterTile(2);
            const string ExpectLabel = "b";
            string actualLabel = numberTile.Label;

            Assert.AreEqual(ExpectLabel, actualLabel);
        }
    }
}
