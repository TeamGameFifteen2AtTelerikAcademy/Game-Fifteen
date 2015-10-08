namespace GameFifteen.Tests.UI.Console
{
    using System;
    using GameFifteen.Logic.Frames;
    using GameFifteen.Logic.Games;
    using GameFifteen.Logic.Games.Contracts;
    using GameFifteen.Logic.Movers;
    using GameFifteen.Logic.Tiles.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using GameFifteen.UI.Console;

    [TestClass]
    public class GameInitializeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Expect to throw if reader is null")]
        public void ExpectToThrowWhenNoReaderIsProvided()
        {
            var printer = new Printer();
            var gameInitializer = new GameInitializator(printer, null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Expect to throw if priner is null")]
        public void ExpectToThrowWhenNoPrinerIsProvided()
        {
            var reader = new Reader();
            var gameInitializer = new GameInitializator(null, reader);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Expect to throw if priner is null")]
        public void ExpectToThrowWhenNoPrinerAndNoReaderAreProvided()
        {
            var reader = new Reader();
            var gameInitializer = new GameInitializator(null, null);
        }

        [TestMethod]
        public void ExpectNotToThrowWhenPrinterAndReaderAreProvided()
        {
            var printer = new Printer();
            var reader = new Reader();
            var gameInitializer = new GameInitializator(printer, reader);
        }
    }
}
