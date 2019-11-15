using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HertiageWalks.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StopList : ContentPage
	{
		public StopList ()
		{
			InitializeComponent ();
		}

        public void StopClicked(Object Sender, EventArgs args)
        {
            Button button = (Button)Sender;
            string ID = button.CommandParameter.ToString();
            // Do your Stuff.....
        }

        async void TrailClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrailPage());
        }

        async void MapClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StopList());
        }
        async void HomeClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

    }
}