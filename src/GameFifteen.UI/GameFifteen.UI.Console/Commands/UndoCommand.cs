using GameFifteen.Logic.Commands;

namespace GameFifteen.UI.Console.Commands
{
    public class UndoCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.Game.Frame = context.BoardHistory.Undo();
        }
    }
}
