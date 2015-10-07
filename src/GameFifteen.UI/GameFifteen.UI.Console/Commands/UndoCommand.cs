namespace GameFifteen.UI.Console.Commands
{
    using GameFifteen.Logic.Commands;

    public class UndoCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.Game.Frame = context.BoardHistory.Undo();
        }
    }
}
