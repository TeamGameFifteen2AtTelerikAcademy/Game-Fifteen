// <copyright file="AboutViewModel.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// AboutViewModel class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.WPF.ViewModels
{
    using System.Collections.ObjectModel;

    using Models;

    /// <summary>
    /// AboutViewModel class - bind with AboutView.
    /// </summary>
    public class AboutViewModel : ViewModelBase
    {
        /// <summary>
        /// Holds OC of masters.
        /// </summary>
        private ObservableCollection<MasterModel> masters;

        /// <summary>
        /// Gets the masters.
        /// </summary>
        /// <value>OC of masters.</value>
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
