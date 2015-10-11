namespace GameFifteen.Tests.UI.Console
{
    using System;
    using GameFifteen.UI.Console;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class GameInitializeTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Expect to throw if reader is null")]
        public void ExpectToThrowWhenNoReaderIsProvided()
        {
            var printer = new Printer();
            var gameInitializer = new GameInitializer(printer, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Expect to throw if priner is null")]
        public void ExpectToThrowWhenNoPrinerIsProvided()
        {
            var reader = new Reader();
            var gameInitializer = new GameInitializer(null, reader);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Expect to throw if priner is null")]
        public void ExpectToThrowWhenNoPrinerAndNoReaderAreProvided()
        {
            var reader = new Reader();
            var gameInitializer = new GameInitializer(null, null);
        }

        [TestMethod]
        public void ExpectNotToThrowWhenPrinterAndReaderAreProvided()
        {
            var printer = new Printer();
            var reader = new Reader();
            var gameInitializer = new GameInitializer(printer, reader);
        }
    }
}
