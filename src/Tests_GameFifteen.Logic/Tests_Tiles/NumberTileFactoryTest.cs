// <copyright file="NumberTileFactoryTest.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// NumberTileFactoryTest class.
// </summary>
// <author>GameFifteen2Team</author>

namespace Tests_GameFifteen.Logic.Tests_Tiles
{
    using GameFifteen.Logic.Tiles;
    using GameFifteen.Logic.Tiles.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// NumberTileFactoryTest test class tests NumberTileFactory.
    /// </summary>
    [TestClass]
    public class NumberTileFactoryTest
    {
        /// <summary>
        /// The method test the tile factory creates tile.
        /// </summary>
        [TestMethod]
        public void TestNumberTileFactoryCreations()
        {
            var factory = new NumberTileFactory();
            var numberTile = factory.CreateTile();
            Assert.IsInstanceOfType(numberTile, typeof(ITile));
        }

        /// <summary>
        /// The method test the tile factory creates tile with next ID.
        /// </summary>
        [TestMethod]
        public void TestNumberTileFactoryCreationsWithNextID()
        {
            var factory = new NumberTileFactory();
            var tileWithIdTwo = factory.CreateTile();
            var tileWithIdThree = factory.CreateTile();
            bool result = tileWithIdTwo.Id == (tileWithIdThree.Id - 1);
            Assert.IsTrue(result);
        }
    }
}
