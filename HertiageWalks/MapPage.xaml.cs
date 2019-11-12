using BruTile.Predefined;
using BruTile.Wms;
using Mapsui;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.Providers;
using Mapsui.Styles;
using Mapsui.UI;
using Mapsui.UI.Forms;
using Mapsui.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HertiageWalks
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
        private Map map;

        public MapPage()
        {
            InitializeComponent();
            mapView.Map = CreateMap();
            mapView.Info += StopInfo;
            //var view = new MapView();
        }


        async void TrailClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrailPage());
        }

        async void StopClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StopList());
        }
        async void HomeClicked(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        public void StopInfo(object sender, MapInfoEventArgs e)
        {
            if (e.MapInfo.Feature != null)
            {

                GoToStop();

            }
        }

        async void GoToStop()
        {
            await Navigation.PushAsync(new StopPage());
        }

        public Mapsui.Map CreateMap()
        {
            map = new Map();
            map.Layers.Add(OpenStreetMap.CreateTileLayer());
            map.Layers.Add(CreatePointLayer());
            //   LoadPoints();

            return map;
        }

        private static MemoryLayer CreatePointLayer()
        {
            return new MemoryLayer
            {
                Name = "Points",
                IsMapInfoLayer = true,
                DataSource = new MemoryProvider(GetStops()),

            };
        }
        private static Features GetStops()
        {
            // Prepare a features variable, and build the data to populate it.
            var features = new Features();
            List<string> list = new List<string>();
            list.Add("someday");


            // Add each stop as a feature to features.
            foreach (var stop in list)
            {
                // Get the coordinates for each stop.
                var coordinates = SphericalMercator.FromLonLat(115.85713, -31.95496);


                // Add the new Feature to Features.
                features.Add(new Feature
                {
                    Geometry = coordinates,
                    ["Label"] = stop,
                });
            }
            // Return the features.
            return features;
        }


    }

}
