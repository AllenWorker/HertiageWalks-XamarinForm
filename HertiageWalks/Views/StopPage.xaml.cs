using Plugin.SimpleAudioPlayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HertiageWalks.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopPage : ContentPage
    {
        public ISimpleAudioPlayer player = CrossSimpleAudioPlayer.Current;

        public StopPage()
        {
            InitializeComponent();
            ISimpleAudioPlayer player = CrossSimpleAudioPlayer.Current;
            string url = "https://heritage-walks.screencraft.net.au/audio/default.mp3";
            WebClient wc = new WebClient();
            Stream fileStream = wc.OpenRead(url);
            player.Load(fileStream);
        }

        /// <summary>
        /// Plays audio 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PlayClicked(object sender, EventArgs e)
        {
            player.Play();
            AudioButton.Text = "Pause";
            AudioButton.Clicked += PauseClicked;
        }

        /// <summary>
        /// Plays audio 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void PauseClicked(object sender, EventArgs e)
        {
            player.Pause();
            AudioButton.Text = "Play";
            AudioButton.Clicked += PlayClicked;
        }



        async void HelpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPage());
        }

    }
}