namespace Tests_GameFifteen.Logic.Tests_Tiles
{
    using GameFifteen.Logic.Tiles;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Summary description for LetterTileTest
    /// </summary>
    [TestClass]
    public class LetterTileTest
    {
        /// <summary>
        /// Gets or sets the test context which provides
        /// information about and functionality for the current test run.
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
