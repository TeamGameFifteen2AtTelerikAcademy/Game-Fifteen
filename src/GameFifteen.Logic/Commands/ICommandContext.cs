namespace GameFifteen.Logic.Commands
{
    using Games.Contracts;
    using Scoreboards.Contracts;

    public interface ICommandContext
    {
        IGame Game { get; set; }

        IScoreboard ScoreboardInfo { get; set; }

        string Message { get; set; }

        string SelectedTileLabel { get; set; }
    }
}
