namespace GameFifteen.UI.Console.Commands
{
    using GameFifteen.Logic.Commands;

    public class ShowScoresCommand : ICommand
    {
        public void Execute(ICommandContext context)
        {
            context.Message = context.ScoreboardInfo.ToString();
        }
    }
}
