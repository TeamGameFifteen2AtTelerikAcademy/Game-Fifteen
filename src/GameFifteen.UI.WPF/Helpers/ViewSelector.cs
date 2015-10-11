// <copyright file="ViewSelector.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ViewSelector class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.WPF.Helpers
{
    using Views;

    /// <summary>
    /// ViewSelector class that holds only instances for each view.
    /// </summary>
    public static class ViewSelector
    {
        /// <summary>
        /// Holds PreGameView.
        /// </summary>
        public static readonly PreGameView PreGame = new PreGameView();

        /// <summary>
        /// Holds GameView.
        /// </summary>
        public static readonly GameView Game = new GameView();

        /// <summary>
        /// Holds GameSettingsView.
        /// </summary>
        public static readonly GameSettingsView GameSettings = new GameSettingsView();

        /// <summary>
        /// Holds AboutView.
        /// </summary>
        public static readonly AboutView About = new AboutView();

        /// <summary>
        /// Holds HallOfFameView.
        /// </summary>
        public static readonly HallOfFameView HallOfFame = new HallOfFameView();

        /// <summary>
        /// Holds CompletedGameView.
        /// </summary>
        public static readonly CompletedGameView JustCompletedGame = new CompletedGameView();

        /// <summary>
        /// Holds CompletedWithTopScoreView.
        /// </summary>
        public static readonly CompletedWithTopScoreView CompleteTopScoreGame = new CompletedWithTopScoreView();

        /// <summary>
        /// Holds AudioNavigationView.
        /// </summary>
        public static readonly AudioNavigationView AudioNav = new AudioNavigationView();
    }
}