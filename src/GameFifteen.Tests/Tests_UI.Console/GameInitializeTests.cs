// <copyright file="GameInitializeTests.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Unit testing UI Console.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Tests.UI.Console
{
    using System;
    using GameFifteen.UI.Console;
    using GameFifteen.UI.Console.ConsoleUserInterfaceIOHandlers;
    using GameFifteen.UI.Console.GameInitializer;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Class test GameInitializeTests.
    /// </summary>
    [TestClass]
    public class GameInitializeTests
    {
        /// <summary>
        /// Test that expect to throw when no reader is provided.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Expect to throw if reader is null")]
        public void ExpectToThrowWhenNoReaderIsProvided()
        {
            var printer = new Printer();
            var gameInitializer = new GameInitializer(printer, null);
        }

        /// <summary>
        /// Test that expect to throw when no printer is provided.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Expect to throw if priner is null")]
        public void ExpectToThrowWhenNoPrinerIsProvided()
        {
            var reader = new Reader();
            var gameInitializer = new GameInitializer(null, reader);
        }

        /// <summary>
        /// Test that expect to throw when no printer and reader are provided.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Expect to throw if priner is null")]
        public void ExpectToThrowWhenNoPrinerAndNoReaderAreProvided()
        {
            var reader = new Reader();
            var gameInitializer = new GameInitializer(null, null);
        }

        /// <summary>
        /// Test that expect not to throw when printer and reader are provided.
        /// </summary>
        [TestMethod]
        public void ExpectNotToThrowWhenPrinterAndReaderAreProvided()
        {
            var printer = new Printer();
            var reader = new Reader();
            var gameInitializer = new GameInitializer(printer, reader);
        }
    }
}
