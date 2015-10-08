namespace GameFifteen.UI.Console
{
    using System;
    using Commands;
    using GameFifteen.Logic.Commands;

    internal class CommandManager : ICommandManager
    {
        public CommandManager()
        {
        }

        public ICommand GetCommand(string command)
        {
            UserCommands userCommand;
            if (Enum.IsDefined(typeof(UserCommands), command) &&
             Enum.TryParse<UserCommands>(command, out userCommand))
            {
                return this.GetCommand(userCommand);
            }
            else
            {
                return new IncorrectCommand();
            }
        }

        public ICommand GetCommand(Enum command)
        {
            switch ((UserCommands)command)
            {
                case UserCommands.Restart:
                    return new RestartCommand();
                case UserCommands.Top:
                    return new ShowScoresCommand();
                case UserCommands.Exit:
                    return new ExitCommand();
                case UserCommands.Undo:
                    return new UndoCommand();
                case UserCommands.Move:
                    return new MoveCommand();
                default:
                    return new IncorrectCommand();
            }
        }
    }
}