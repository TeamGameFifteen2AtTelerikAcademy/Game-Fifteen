namespace GameFifteen.UI.WPF.Helpers
{
    using ViewModels;

    public static class ViewModelsSelector
    {
        public static readonly GameSettingsViewModel GameSettingsViewModel = new GameSettingsViewModel();
        public static readonly GameViewModel GameViewModel = new GameViewModel();
        public static readonly PreGameViewModel PreGameViewModel = new PreGameViewModel();
        public static readonly ViewModelBase ViewModelBase = new ViewModelBase();
        public static readonly AboutViewModel AboutViewModel = new AboutViewModel();
    }
}
