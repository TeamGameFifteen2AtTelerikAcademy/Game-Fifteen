namespace Tests_GameFifteen.Logic.Tests_Scoreboards
{
    using System;
    using System.Linq;
    using GameFifteen.Logic;
    using GameFifteen.Logic.Common;
    using GameFifteen.Logic.Scoreboards;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Covers tests for Scoreboard
    /// </summary>
    [TestClass]
    public class ScoreboardTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
          "Parameter must be a positive integer")]
        public void ExpectScoreboardAddMethodToThrowsWhenNonePositiveIntegerForMovesIsProvided()
        {
            var scoreboard = new Scoreboard();
            var moves = -1;
            var playerName = "Test Player";

            scoreboard.Add(moves, playerName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Parameter must be a positive integer")]
        public void ExpectScoreboardAddMethodToThrowsWhenZeroIntegerForMovesIsProvided()
        {
            var scoreboard = new Scoreboard();
            var moves = 0;
            var playerName = "Test Player";

            scoreboard.Add(moves, playerName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
          "Argument name cannot be null!")]
        public void ExpectScoreboardAddMethodToThrowsWhenNullIsProvidedForPlayerNameParameter()
        {
            var scoreboard = new Scoreboard();
            var moves = 5;
            string playerName = null;

            scoreboard.Add(moves, playerName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException),
         "Parameter must be a positive integer")]
        public void ExpectScoreboardAddMethodToThrowsWhenNullIsProvidedForPlayerNameAndNonPositiveIntegerForMoves()
        {
            var scoreboard = new Scoreboard();
            var moves = -5;
            string playerName = null;

            scoreboard.Add(moves, playerName);
        }

        [TestMethod]
        public void ExpectScoreboardAddMethodToAddScoreToTopsScores()
        {
            var moves = 5;
            var playerName = "Test Player";
            var scoreboard = new Scoreboard();
            scoreboard.Add(moves, playerName);
            var topScore = scoreboard.GetTopScores()[0];

            Assert.IsInstanceOfType(topScore, typeof(Score));
        }

        [TestMethod]
        public void ExpectScoreboardIsInTopScoresMethodToToreturnTrueWhenLessThanMaxCountOfScoresAreInTopScores()
        {
            var scoreboard = new Scoreboard();
            var moves = 5;
            var expecterIsInTopScore = scoreboard.IsInTopScores(moves);

            Assert.IsTrue(expecterIsInTopScore);
        }

        [TestMethod]
        public void ExpectScoreboardIsInTopScoresMethodToToreturnFalseWhenIsOutOfTopScores()
        {
            var scoreboard = new Scoreboard();
            var playerName = "Test Player";
            var maxCountTopScores = Constants.ScoreboardMaxCount;

            for (int moves = 1; moves <= maxCountTopScores; moves++)
            {
                scoreboard.Add(moves, playerName);
            }

            var expecterIsInTopScore = scoreboard.IsInTopScores(maxCountTopScores + 1);

            Assert.IsFalse(expecterIsInTopScore);
        }

        [TestMethod]
        public void ExpectScoreboardIsInTopScoresMethodToToreturnTrueWhenTopScorProvided()
        {
            var scoreboard = new Scoreboard();
            var playerName = "Test Player";
            var maxCountTopScores = Constants.ScoreboardMaxCount;

            for (int moves = 1; moves <= maxCountTopScores; moves++)
            {
                scoreboard.Add(moves, playerName);
            }

            var expecterIsInTopScore = scoreboard.IsInTopScores(maxCountTopScores - 1);

            Assert.IsTrue(expecterIsInTopScore);
        }

        [TestMethod]
        public void ExpectScoreboardAddMethodNotToAddScoreToTopsScoresWhenIsNotInTopScores()
        {
            var scoreboard = new Scoreboard();
            var playerName = "Test Player";
            var maxCountTopScores = Constants.ScoreboardMaxCount;

            for (int moves = 1; moves <= maxCountTopScores; moves++)
            {
                scoreboard.Add(moves, playerName);
            }

            scoreboard.Add(maxCountTopScores + 1, playerName);

            var actualCountOfScoresOutOfTop = scoreboard.GetTopScores()
                .Where(s => s.Moves == maxCountTopScores + 1)
                .Count();

            var expectedCountOfScoresOutOfTop = 0;

            Assert.AreEqual(expectedCountOfScoresOutOfTop, actualCountOfScoresOutOfTop);
        }

        [TestMethod]
        public void ExpectScoreboardToStringReturnsConstanstScoreoardIsEmptyString()
        {
            var scoreboard = new Scoreboard();
            var actualToString = scoreboard.ToString();
            var expectedToString = Constants.ScoreboardIsEmpty
                 + Environment.NewLine;

            Assert.AreEqual(expectedToString, actualToString);
        }

        [TestMethod]
        public void ExpectScoreboardToStringReturnsCorrectScoreboardString()
        {
            var scoreboard = new Scoreboard();
            var moves = 5;
            var playerName = "Test Player";
            scoreboard.Add(moves, playerName);

            var actualToString = scoreboard.ToString();
            var expectedToString = Constants.Scoreboard +
                                   Environment.NewLine +
                                   string.Format(Constants.ScoreboardFormat, 1, playerName, moves) +
                                   Environment.NewLine;

            Assert.AreEqual(expectedToString, actualToString);
        }
    }
}