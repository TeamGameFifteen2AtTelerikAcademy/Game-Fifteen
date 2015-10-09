using System;
using System.Security.Cryptography.X509Certificates;
using GameFifteen.Logic.Memento;
using GameFifteen.Logic.Scoreboards;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameFifteen.UI.Console;

namespace GameFifteen.Tests.UI.Console
{
    [TestClass]
    public class EngineTests
    {
        [TestMethod]
        public void ExpectEngineToRunProperlyAndForcedExitAfterTwoSteps()
        {
            var reader = MockStorage.GetReader("exit");

            var engine = new Engine(

                MockStorage.GetGame(),
                new Scoreboard(),
                MockStorage.GetPrinter(),
                reader,
                new CommandManager(),
                new BoardHistory()

                );
            
            engine.Run();
        }

        [TestMethod]
        public void ExpectToExecuteGameOverWhenGameIsSolved()
        {
            var reader = MockStorage.GetReader("exit");

            var engine = new Engine(

                MockStorage.GetSolvedGame(),
                new Scoreboard(),
                MockStorage.GetPrinter(),
                reader,
                new CommandManager(),
                new BoardHistory()

                );

            engine.Run();
        }
    }
}
