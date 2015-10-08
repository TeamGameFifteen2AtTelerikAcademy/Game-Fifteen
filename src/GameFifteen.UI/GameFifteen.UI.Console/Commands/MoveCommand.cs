namespace GameFifteen.UI.Console.Commands
{
    using Logic.Commands;
    using Logic.Common;

    public class MoveCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.BoardHistory.SaveBoardState(context.Game.Frame);
            bool isSuccessfulMove = context.Game.Move(context.SelectedTileLabel);
            if (isSuccessfulMove)
            {
                context.Moves += 1;
                context.Message = string.Empty;
            }
            else
            {
                context.Message = Constants.InvalidMoveMessage;
            }
        }
    }
}
