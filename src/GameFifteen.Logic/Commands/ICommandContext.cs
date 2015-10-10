// <copyright file="ICommandContext.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// Interface for ICommandContext.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.Logic.Commands
{
    using Games.Contracts;
    using Memento;
    using Scoreboards.Contracts;

    /// <summary>
    /// Interface for ICommandContext.
    /// </summary>
    public interface ICommandContext
    {
        /// <summary>
        /// Gets or sets Game of type IGame.
        /// </summary>
        /// <value>Object of type IGame.</value>
        IGame Game { get; set; }

        /// <summary>
        /// Gets or sets BoardHistory of type IMemento.
        /// </summary>
        /// <value>Object of type IMemento.</value>
        IMemento BoardHistory { get; set; }

        /// <summary>
        /// Gets or sets ScoreboardInfo of type IScoreboard.
        /// </summary>
        /// <value>Object of type IScoreboard.</value>
        IScoreboard ScoreboardInfo { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is the game over.
        /// </summary>
        /// <value>Object of type Boolean.</value>
        bool IsGameOver { get; set; }

        /// <summary>
        /// Gets or sets Message of type String.
        /// </summary>
        /// <value>Object of type String.</value>
        string Message { get; set; }

        /// <summary>
        /// Gets or sets SelectedTileLabel of type String.
        /// </summary>
        /// <value>Object of type String.</value>
        string SelectedTileLabel { get; set; }

        /// <summary>
        /// Gets or sets Moves of type integer.
        /// </summary>
        /// <value>Object of type Integer.</value>
        int Moves { get; set; }
    }
}