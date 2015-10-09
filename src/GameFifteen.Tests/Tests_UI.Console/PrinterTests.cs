namespace GameFifteen.Tests.UI.Console
{
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
            var mockedPrinter = new Mock<IPrinter>();
            var result = string.Empty;

            mockedPrinter.Setup(l => l.Print(frame))
                .Callback<object>((s) => { result = s.ToString(); });

            mockedPrinter.Object.Print(frame);

            Assert.AreEqual(frame.ToString(), result);
            mockedPrinter.Verify(x => x.Print(frame), Times.AtMostOnce);
        }

        [TestMethod]
        public void ExpectPrintLineMethodToWorkCorrectlyWithFrame()
        {
            var frame = new Frame(new ITile[3, 3]);
            var mockedPriner = new Mock<IPrinter>();
            var result = string.Empty;

            mockedPriner.Setup(l => l.PrintLine(frame))
                .Callback<object>((s) => { result = s.ToString(); });

            mockedPriner.Object.PrintLine(frame);

            Assert.AreEqual(frame.ToString(), result);
            mockedPriner.Verify(x => x.PrintLine(frame), Times.AtMostOnce);
        }
    }
}
