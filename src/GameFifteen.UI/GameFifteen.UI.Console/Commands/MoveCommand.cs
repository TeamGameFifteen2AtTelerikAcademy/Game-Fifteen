namespace GameFifteen.UI.Console.Commands
{
    using System;
    using Logic.Commands;

    class MoveCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.Game.Move(context.SelectedTileLabel);
        }
    }
}
