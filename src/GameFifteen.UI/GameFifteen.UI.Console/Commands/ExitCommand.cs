namespace GameFifteen.UI.Console.Commands
{
    using System;
    using Logic.Commands;
    using Logic.Common;

    public class ExitCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.Message = Constants.GoodbyeMessage;
            Environment.Exit(0);
        }
    }
}
