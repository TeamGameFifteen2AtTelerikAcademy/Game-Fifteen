using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameFifteen.Logic.Commands
{
    public interface ICommandManager
    {
        ICommand GetCommand(string command);
    }
}
