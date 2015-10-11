namespace Tests_GameFifteen.Logic.Tests_Tiles
{
    using GameFifteen.Logic.Tiles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for NumberTileTest
    /// </summary>
    [TestClass]
    public class NumberTileTest
    {
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
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
