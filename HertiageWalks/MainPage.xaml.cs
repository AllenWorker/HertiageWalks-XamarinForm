using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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
            //TrailView.ItemTemplate = new DataTemplate(typeof(CustomCell));
        }

        public void TrailClicked(Object Sender, EventArgs args)
        {
            Button button = (Button)Sender;
            string ID = button.CommandParameter.ToString();
            // Do your Stuff.....
        }
    }
}
