using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen.Logic.Commands
{
    public interface ICommand
    {
        void Execute(ICommandContext ctx);
    }
}
