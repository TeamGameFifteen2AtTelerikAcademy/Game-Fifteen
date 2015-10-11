namespace Tests_GameFifteen.Logic.Tests_Tiles
{
    using GameFifteen.Logic.Tiles;
    using GameFifteen.Logic.Tiles.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for LetterTileFactoryTest
    /// </summary>
    [TestClass]
    public class LetterTileFactoryTest
    {
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
        /// </summary>
        [TestMethod]
        public void TestLetterTileFactoryCreations()
        {
            var factory = new LetterTileFactory();
            var letterTile = factory.CreateTile();
            Assert.IsInstanceOfType(letterTile, typeof(ITile));
        }

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
