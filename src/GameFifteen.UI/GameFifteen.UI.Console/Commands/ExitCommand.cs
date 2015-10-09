namespace GameFifteen.UI.Console.Commands
{
    using System;
    using Logic.Commands;
    using Logic.Common;

    public class ExitCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.IsGameOver = true;
            context.Message = string.Empty;
        }
    }
}
