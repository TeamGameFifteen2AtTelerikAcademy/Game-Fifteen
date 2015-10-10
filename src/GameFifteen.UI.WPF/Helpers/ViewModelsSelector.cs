// <copyright file="ViewModelsSelector.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// ViewModelsSelector class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.WPF.Helpers
{
    using ViewModels;

    /// <summary>
    /// ViewModelsSelector class keeps only instances of each view model to ensure there only one instance of each.
    /// </summary>
    public static class ViewModelsSelector
    {
        /// <summary>
        /// Holds GameSettingsViewModel.
        /// </summary>
        public static readonly GameSettingsViewModel GameSettingsViewModel = new GameSettingsViewModel();

        /// <summary>
        /// Holds GameViewModel.
        /// </summary>
        public static readonly GameViewModel GameViewModel = new GameViewModel();

        /// <summary>
        /// Holds PreGameViewModel.
        /// </summary>
        public static readonly PreGameViewModel PreGameViewModel = new PreGameViewModel();

        /// <summary>
        /// Holds ViewModelBase.
        /// </summary>
        public static readonly ViewModelBase ViewModelBase = new ViewModelBase();

        /// <summary>
        /// Holds AboutViewModel.
        /// </summary>
        public static readonly AboutViewModel AboutViewModel = new AboutViewModel();
    }
}
