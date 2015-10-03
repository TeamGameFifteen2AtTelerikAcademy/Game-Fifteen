namespace GameFifteen.UI.Console.Commands
{
    using System;
    using Logic.Commands;
    using Logic.Common;

    class ExitCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
          context.Printer.PrintLine(Constants.GoodbyeMessage);
            Environment.Exit(0);     
        }
    }
}
