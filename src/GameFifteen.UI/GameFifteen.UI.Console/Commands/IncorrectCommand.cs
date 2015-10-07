namespace GameFifteen.UI.Console.Commands
{
    using GameFifteen.Logic.Commands;
    using Logic.Common;

    public class IncorrectCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.Message = Constants.InvalidCommandMessage;
        }
    }
}
