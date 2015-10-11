namespace GameFifteen.Tests.UI.Console
{
    using System.IO;
    using GameFifteen.Logic.Frames;
    using GameFifteen.Logic.Tiles.Contracts;
    using GameFifteen.UI.Console;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    /// <summary>
    /// Summary description for PrinterTests
    /// </summary>
    [TestClass]
    public class PrinterTests
    {
       [TestMethod]
        public void ExpectPrintMethodToWorkCorrectlyWithFrame()
        {
            var frame = new Frame(new ITile[3, 3]);
            var printer = new Printer();
            printer.Print(frame);
        }

        [TestMethod]
        public void ExpectPrintLineMethodToWorkCorrectlyWithFrame()
        {
            var frame = new Frame(new ITile[3, 3]);
          
            var printer = new Printer();
            printer.PrintLine(frame);
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void ExpectSetCursorBottomBoardToInvokeConsoleSetCursorPositionAndThrow()
        {
            var printer = new Printer();
            printer.SetCursorBottomBoard();
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void ExpectSetCursorTopBoardToInvokeConsoleSetCursorPositionAndThrow()
        {
            var printer = new Printer();
            printer.SetCursorTopBoard();
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void ExpectClearBoardToInvokeConsoleSClearAndThrow()
        {
            var printer = new Printer();
            printer.ClearBoard();
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void ExpectClearLineToInvokeConsoleSetCursorPositionAndThrow()
        {
            var printer = new Printer();
            printer.ClearLine();
        }

        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void ExpectClearMessagesToInvokeConsoleSetCursorPositionAndThrow()
        {
            var printer = new Printer();
            printer.ClearMessages();
        }
    }
}