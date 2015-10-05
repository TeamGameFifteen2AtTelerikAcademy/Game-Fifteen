namespace GameFifteen.UI.Console.Commands
{
    using Logic.Commands;

    class MoveCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.BoardHistory.SaveBoardState(context.Game.Frame);
            context.Game.Move(context.SelectedTileLabel);
          
            context.Message = string.Empty;
        }
    }
}
