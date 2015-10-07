using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFifteen.UI.WPF.ViewModels
{
    class ViewModels
    {
        private static GameSettingsViewModel settings;
        private static GameViewModel game;
        private static PreGameViewModel preGame;
        private static ViewModelBase baseModel;
        private static AboutViewModel about;

        public static GameSettingsViewModel GameSettingsViewModel
        {
            get
            {
                if (settings == null)
                {
                    settings = new GameSettingsViewModel();
                }

                return settings;
            }
        }

        public static GameViewModel GameViewModel
        {
            get
            {
                if (game == null)
                {
                    game = new GameViewModel();
                }

                return game;
            }
        }

        public static PreGameViewModel PreGameViewModel
        {
            get
            {
                if (preGame == null)
                {
                    preGame = new PreGameViewModel();
                }

                return preGame;
            }
        }

        public static ViewModelBase ViewModelBase
        {
            get
            {
                if (baseModel == null)
                {
                    baseModel = new ViewModelBase();
                }

                return baseModel;
            }
        }

        public static AboutViewModel AboutViewModel
        {
            get
            {
                if (about == null)
                {
                    about = new AboutViewModel();
                }

                return about;
            }
        }
    }
}
