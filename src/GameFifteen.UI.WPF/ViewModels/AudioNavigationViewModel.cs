// <copyright file="AudioNavigationViewModel.cs" company="GameFifteen2Team">
// The MIT License (MIT)
// Copyright(c) 2015 Team "Game-Fifteen-2"
// </copyright>
// <summary>
// AudioNavigationViewModel class.
// </summary>
// <author>GameFifteen2Team</author>

namespace GameFifteen.UI.WPF.ViewModels
{
    using System;
    using System.Windows.Input;
    using System.Windows.Media;

    using Commands;

    /// <summary>
    /// AudioNavigationViewModel class - bind with AudioNavigationView.
    /// </summary>
    public class AudioNavigationViewModel : ViewModelBase
    {
        /// <summary>
        /// Holds the constant string for the path to the audio source.
        /// </summary>
        private const string AudoiPath = "./Resources/NoGood.mp3";

        /// <summary>
        /// Holds the MediaPlayer object.
        /// </summary>
        private readonly MediaPlayer mediaPlayer = new MediaPlayer();

        /// <summary>
        /// Holds the status is the audio is paused or is playing.
        /// </summary>
        private bool isPlaying = false;

        /// <summary>
        /// Holds command for toggle the playing state of the audio.
        /// </summary>
        private ICommand audioTogglePlayCommand;

        /// <summary>
        /// Initializes a new instance of the AudioNavigationViewModel class.
        /// </summary>
        public AudioNavigationViewModel()
        {
            this.mediaPlayer.Open(new Uri(AudioNavigationViewModel.AudoiPath, UriKind.Relative));
            this.mediaPlayer.MediaEnded += new EventHandler(this.MediaEnded);
        }

        /// <summary>
        /// Gets or sets a value indicating whether the audio is playing or is paused.
        /// Bind with controls.
        /// </summary>
        /// <value>The state of the audio.</value>
        public bool IsPlaying
        {
            get
            {
                return this.isPlaying;
            }

            set
            {
                this.isPlaying = value;
                this.OnPropertyChanged("isPlaying");
            }
        }

        /// <summary>
        /// Gets the audio toggle play command.
        /// Bind with controls.
        /// </summary>
        /// <value>AudioTogglePlay as ICommand.</value>
        public ICommand AudioTogglePlay
        {
            get
            {
                if (this.audioTogglePlayCommand == null)
                {
                    this.audioTogglePlayCommand = new RelayCommand(this.HandleAudioaudioTogglePlayCommand);
                }

                return this.audioTogglePlayCommand;
            }
        }

        /// <summary>
        /// The method handles audioTogglePlayCommand.
        /// </summary>
        /// <param name="parameter">The sender of the command.</param>
        private void HandleAudioaudioTogglePlayCommand(object parameter)
        {
            if (this.IsPlaying)
            {
                this.mediaPlayer.Pause();
                this.IsPlaying = false;
            }
            else
            {
                this.mediaPlayer.Play();
                this.IsPlaying = true;
            }
        }

        /// <summary>
        /// The method is used for loop the audio, called by MediaPlayer.MediaEnded EventHandler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The event arguments.</param>
        private void MediaEnded(object sender, EventArgs e)
        {
            var media = sender as MediaPlayer;
            if (media != null && media.HasAudio == true)
            {
                media.Position = TimeSpan.Zero;
            }
        }
    }
}
