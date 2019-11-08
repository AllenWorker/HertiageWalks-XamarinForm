
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HertiageWalks.Core.ViewModel;


using HertiageWalks.Core.Model;




namespace HertiageWalks
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

        }

        /// <summary>
        /// for the trail page 
        /// </summary>
        /// <param name="Sender"></param>
        /// <param name="args"></param>
        async void TrailClicked(object s, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new TrailPage());

        }

        /// <summary>
        /// opens the help page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        async void HelpClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPage());
        }


    }
}
