namespace GameFifteen.UI.Console.Commands
{
    using GameFifteen.Logic.Commands;

    class ShowScoresCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.Message = context.ScoreboardInfo.ToString();
        }
    }
}
