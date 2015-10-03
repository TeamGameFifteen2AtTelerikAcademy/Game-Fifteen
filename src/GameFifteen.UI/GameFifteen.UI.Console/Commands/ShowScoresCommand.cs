using GameFifteen.Logic.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteen.UI.Console.Commands
{
    class ShowScoresCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.Printer.Print(context.Game.Scoreboard);
            context.Printer.PrintLine(context.Game);
        }
    }
}
