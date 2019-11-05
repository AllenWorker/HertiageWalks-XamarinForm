
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
            ToolbarItem item = new ToolbarItem
            {
                Text = "Example Item",
                IconImageSource = ImageSource.FromFile("example_icon.png"),
                Order = ToolbarItemOrder.Primary,
                Priority = 0
            };
            item.Clicked += OnItemClicked;
            // "this" refers to a Page object
            this.ToolbarItems.Add(item);

            //TrailView.ItemTemplate = new DataTemplate(typeof(CustomCell));
        }

        public void TrailClicked(Object Sender, EventArgs args)
        {
            Button button = (Button)Sender;
            string ID = button.CommandParameter.ToString();
            // Do your Stuff.....
        }

        void OnItemClicked(object sender, EventArgs e)
        {
            ToolbarItem item = (ToolbarItem)sender;
          Console.Out.WriteLine ("You clicked the \"{item.Text}\" toolbar item.");
        }
        async void OnHelpPageClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPage());
        }

    }
}
