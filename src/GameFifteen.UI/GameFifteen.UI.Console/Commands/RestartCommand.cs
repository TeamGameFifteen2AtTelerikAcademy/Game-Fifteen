namespace GameFifteen.UI.Console.Commands
{
    using GameFifteen.Logic.Commands;
    using Logic.Common;

    public class RestartCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.Game.Shuffle();
            context.Message = Constants.WellcomeMessage;
            context.BoardHistory.ClearHistory();
            context.BoardHistory.SaveBoardState(context.Game.Frame);
            context.Moves = 0;
        }
    }
}
