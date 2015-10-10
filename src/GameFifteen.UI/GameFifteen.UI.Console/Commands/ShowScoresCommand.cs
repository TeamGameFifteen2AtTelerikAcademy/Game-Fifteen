// <copyright file="ShowScoresCommand.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ShowScoresCommand class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.Console.Commands
{
    using GameFifteen.Logic.Commands;

    /// <summary>
    /// ShowScoresCommand class.
    /// </summary>
    public class ShowScoresCommand : ICommand
    {
        /// <summary>
        /// The method accepts ICommandContext to execute show scores command.
        /// </summary>
        /// <param name="context">Context of type ICommandContext.</param>
        public void Execute(ICommandContext context)
        {
            context.Message = context.ScoreboardInfo.ToString();
        }
    }
}
