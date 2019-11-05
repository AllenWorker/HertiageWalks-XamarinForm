using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using HertiageWalks.Core.ViewModel;
using HertiageWalks.Core.Services;

using System.Collections.ObjectModel;
using HertiageWalks.Core.Model;

namespace HertiageWalks
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Trail> MVVMData;
        public MainPage()
        {
            InitializeComponent();
            HeritageWalkService service = new HeritageWalkService();

            MVVMData = new ObservableCollection<Trail>();
            Console.WriteLine(MVVMData.Count);
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
