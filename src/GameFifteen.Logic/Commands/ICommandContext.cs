namespace GameFifteen.Logic.Commands
{
    using Games.Contracts;
    using Memento;
    using Scoreboards.Contracts;

    /// <summary>
    /// Interface for ICommandContext
    /// </summary>
    public interface ICommandContext
    {
        /// <summary>
        /// Public property Game of typeIGame
        /// </summary>
        IGame Game { get; set; }

        /// <summary>
        /// Public property BoardHistory of type IMemento
        /// </summary>
        IMemento BoardHistory { get; set; }

        /// <summary>
        /// Public property ScoreboardInfo of type IScoreboard
        /// </summary>
        IScoreboard ScoreboardInfo { get; set; }

        /// <summary>
        /// Public property IsGameOver of type Boolena
        /// </summary>
        bool IsGameOver { get; set; }

        /// <summary>
        /// Public property Message of type String
        /// </summary>
        string Message { get; set; }

        /// <summary>
        /// Public property SelectedTileLabel of type String
        /// </summary>
        string SelectedTileLabel { get; set; }

        /// <summary>
        /// Public property Moves of type Int32
        /// </summary>
        int Moves { get; set; }
    }
}