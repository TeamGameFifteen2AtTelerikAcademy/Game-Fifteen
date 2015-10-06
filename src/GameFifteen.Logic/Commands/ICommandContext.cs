namespace GameFifteen.Logic.Commands
{
    using Memento;
    using Games.Contracts;
    using Scoreboards.Contracts;

    public interface ICommandContext
    {
        IGame Game { get; set; }

        IMemento BoardHistory { get; set; }

        IScoreboard ScoreboardInfo { get; set; }

        string Message { get; set; }

        string SelectedTileLabel { get; set; }

        int Moves { get; set; }
    }
}
