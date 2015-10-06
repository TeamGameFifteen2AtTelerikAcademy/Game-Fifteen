namespace GameFifteen.UI.Console
{
    using GameFifteen.Logic.Commands;
    using GameFifteen.Logic.Games.Contracts;
    using Logic.Memento;
    using GameFifteen.Logic.Scoreboards.Contracts;

    public class CommandContext : ICommandContext
    {
        public CommandContext(IGame game, IScoreboard scoreboard, IMemento boardHistory)
        {
            this.Game = game;
            this.ScoreboardInfo = scoreboard;
            this.BoardHistory = boardHistory;
            this.Moves = 0;
        }

        public IMemento BoardHistory { get; set; }

        public IScoreboard ScoreboardInfo { get; set; }

        public IGame Game { get; set; }        

        public string Message { get; set; }

        public string SelectedTileLabel { get; set; }     
        
        public int Moves { get; set; }  
    }
}
