namespace GameFifteen.Logic.Commands
{
    using GameFifteen.Logic.Games.Contracts;

    public interface ICommandContext
    {
        IGame Game { get; set; }
        // TODO: get thr printer out of here. Return message instead. 
        IPrinter Printer { get; set; }

        string SelectedTileLabel { get; set;}
    }
}
