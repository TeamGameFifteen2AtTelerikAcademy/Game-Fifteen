using System;
using System.Text;
using System.Collections.Generic;
using GameFifteen.Logic.Tiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests_GameFifteen.Logic.Tests_Tiles
{
    /// <summary>
    /// Summary description for LetterTileTest
    /// </summary>
    [TestClass]
    public class LetterTileTest
    {
        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>


        [TestMethod]
        public void TestLabelOfLetterTile()
        {
            var numberTile = new LetterTile(2);
            const string expectLabel = "b";
            string actualLabel = numberTile.Label;

            Assert.AreEqual(expectLabel, actualLabel);
        }
    }
}
