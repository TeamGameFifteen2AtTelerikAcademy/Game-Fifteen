namespace GameFifteen.UI.WPF.ViewModels
{
    using System.Collections.ObjectModel;

    using Models;

    public class AboutViewModel : ViewModelBase
    {
        private ObservableCollection<MasterModel> masters;

        public ObservableCollection<MasterModel> Masters
        {
            get
            {
                if (this.masters == null)
                {
                    this.masters = new ObservableCollection<MasterModel>()
                    {
                        new MasterModel()
                        {
                            Name = "Dobromira Boycheva",
                            GithbUrl = "https://github.com/dobromiraboycheva",
                            GitgunNick = "dobromiraboycheva",
                            TaNick = "dobromira.boycheva"
                        },
                        new MasterModel()
                        {
                            Name = "Iliyana Antova",
                            GithbUrl = "https://github.com/iliantova",
                            GitgunNick = "iliantova",
                            TaNick = "iliant"
                        },
                        new MasterModel()
                        {
                            Name = "Ivo Paounov",
                            GithbUrl = "https://github.com/IvoPaunov",
                            GitgunNick = "IvoPaunov",
                            TaNick = "ivo.paunov"
                        },
                        new MasterModel()
                        {
                            Name = "Mariya Steffanova",
                            GithbUrl = "https://github.com/MariyaSteffanova",
                            GitgunNick = "MariyaSteffanova",
                            TaNick = "MariyaSteffanova"
                        },
                        new MasterModel()
                        {
                            Name = "Simeon Georgiev",
                            GithbUrl = "https://github.com/SimoPrG",
                            GitgunNick = "SimoPrG",
                            TaNick = "simeon.georgiev.5076"
                        },
                    };
                }

                return this.masters;
            }
        }
    }
}
