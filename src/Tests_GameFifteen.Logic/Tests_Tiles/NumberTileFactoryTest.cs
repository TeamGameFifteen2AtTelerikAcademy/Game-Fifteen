namespace Tests_GameFifteen.Logic.Tests_Tiles
{
    using GameFifteen.Logic.Tiles;
    using GameFifteen.Logic.Tiles.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    /// <summary>
    /// Summary description for NumberTileFactoryTest
    /// </summary>
    [TestClass]
    public class NumberTileFactoryTest
    {

        [TestMethod]
        public void TestNumberTileFactoryCreations()
        {
            var factory = new NumberTileFactory();
            var numberTile = factory.CreateTile();
            Assert.IsInstanceOfType(numberTile, typeof(ITile));
        }


        [TestMethod]
        public void TestNumberTileFactoryCreationsWithNextID()
        {
            var factory = new NumberTileFactory();
            var tileWithIdTwo = factory.CreateTile();
            var tileWithIdThree = factory.CreateTile();
            bool result = (tileWithIdTwo.Id == (tileWithIdThree.Id - 1));
            Assert.IsTrue(result);
        }
    }
}
