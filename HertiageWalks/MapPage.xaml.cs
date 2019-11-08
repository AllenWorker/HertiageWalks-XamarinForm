
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HertiageWalks
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
      
        public MapPage ()
		{
			InitializeComponent ();

        }

        async void MapClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MapPage());
        }

        async void TrailClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrailPage());
        }

        async void StopClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StopList());
        }

        /*  public void StopInfo(object sender, MapInfoEventArgs e)
          {



          }*/


    }
}