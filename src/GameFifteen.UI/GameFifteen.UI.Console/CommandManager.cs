//namespace GameFifteen.UI.Console
//{
//    using System;
//    using GameFifteen.Logic.Commands;
//    using Commands;

//    internal class CommandManager : ICommandManager
//    {
//        public CommandManager()
//        {
//        }

//        public ICommand GetCommand(string command)
//        {
//            switch (command)
//            {
//                case "restart":
//                    return new RestartCommand();
//                case "top":
//                    return new ShowScoresCommand();
//                default:
//                    return new MoveCommand();
//            }
//        }
//    }
//}