// <copyright file="LetterTileFactoryTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// LetterTileFactoryTest class.
// </summary>
// <author>GameFifteen2Team</author>

namespace Tests_GameFifteen.Logic.Tests_Tiles
{
    using GameFifteen.Logic.Tiles;
    using GameFifteen.Logic.Tiles.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// LetterTileFactoryTest test class tests LetterTileFactory.
    /// </summary>
    [TestClass]
    public class LetterTileFactoryTest
    {
        /// <summary>
        /// The method test the tile factory creates tile.
        /// </summary>
        [TestMethod]
        public void TestLetterTileFactoryCreations()
        {
            var factory = new LetterTileFactory();
            var letterTile = factory.CreateTile();
            Assert.IsInstanceOfType(letterTile, typeof(ITile));
        }

        /// <summary>
        /// The method test the tile factory creates tile with next ID.
        /// </summary>
        [TestMethod]
        public void TestNumberTileFactoryCreationsWithNextID()
        {
            var factory = new LetterTileFactory();
            var tileWithIdTwo = factory.CreateTile();
            var tileWithIdThree = factory.CreateTile();
            bool result = tileWithIdTwo.Id == (tileWithIdThree.Id - 1);
            Assert.IsTrue(result);
        }
    }
}
