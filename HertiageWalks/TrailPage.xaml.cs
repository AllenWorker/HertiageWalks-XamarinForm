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
	public partial class TrailPage : ContentPage
	{
		public TrailPage ()
		{
			InitializeComponent ();
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