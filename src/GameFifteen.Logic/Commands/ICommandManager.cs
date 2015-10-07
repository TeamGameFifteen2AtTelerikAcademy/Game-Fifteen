namespace GameFifteen.Logic.Commands
{
    using System;
  
    public interface ICommandManager
    {
        ICommand GetCommand(string command);

        ICommand GetCommand(Enum command);
    }
}
