// <copyright file="CommandContext.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// CommandContext class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console.GameContext
{
    using GameFifteen.Logic.Commands;
    using GameFifteen.Logic.Games.Contracts;
    using GameFifteen.Logic.Memento;
    using GameFifteen.Logic.Scoreboards.Contracts;

    /// <summary>
    /// CommandContext class.
    /// </summary>
    public class CommandContext : ICommandContext
    {
        /// <summary>
        /// Initializes a new instance of the CommandContext class.
        /// </summary>
        /// <param name="game">Command context's IGame.</param>
        /// <param name="scoreboard">Command context'sIScoreboard.</param>
        /// <param name="boardHistory">Command context's IMemento.</param>
        public CommandContext(IGame game, IScoreboard scoreboard, IMemento boardHistory)
        {
            this.Game = game;
            this.ScoreboardInfo = scoreboard;
            this.BoardHistory = boardHistory;
            this.Moves = 0;
        }

        /// <summary>
        /// Gets or sets command context's IMemento.
        /// </summary>
        /// <value>BoardHistory of type IMemento.</value>
        public IMemento BoardHistory { get; set; }

        /// <summary>
        /// Gets or sets command context's IScoreboard.
        /// </summary>
        /// <value>ScoreboardInfo of type IScoreboard.</value>
        public IScoreboard ScoreboardInfo { get; set; }

        /// <summary>
        /// Gets or sets command context's IGame.
        /// </summary>
        /// <value>Game of type IGame.</value>
        public IGame Game { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether command context's game is over.
        /// </summary>
        /// <value>IsGameOver of type boolean.</value>
        public bool IsGameOver { get; set; }

        /// <summary>
        /// Gets or sets command context's Message.
        /// </summary>
        /// <value>Message of type string.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets command context's SelectedTileLabel.
        /// </summary>
        /// <value>SelectedTileLabel of type string.</value>
        public string SelectedTileLabel { get; set; }

        /// <summary>
        /// Gets or sets command context's Moves.
        /// </summary>
        /// <value>Moves of type integer.</value>
        public int Moves { get; set; }  
    }
}
