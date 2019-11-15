using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HertiageWalks.ViewModel;

namespace HertiageWalks.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TrailPage : ContentPage
	{
		public TrailPage (TrailViewModel trailViewModel)
		{
			InitializeComponent ();
            BindingContext = trailViewModel;

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