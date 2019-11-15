using BruTile.Predefined;
using BruTile.Wms;
using HertiageWalks.Model;
using HertiageWalks.ViewModel;
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

namespace HertiageWalks.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapPage : ContentPage
	{
        private Map map;

        public List<StopViewModel> stopList;

        private TrailViewModel trail;

        public MapPage(TrailViewModel trailViewModel)
        {
           
            InitializeComponent();
            trail = trailViewModel;
            mapView.Map = CreateMap();
            mapView.Info += StopInfo;

            //var view = new MapView();
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

            return map;
        }

        private  MemoryLayer CreatePointLayer()
        {
            return new MemoryLayer
            {
                Name = "Points",
                IsMapInfoLayer = true,
                DataSource = new MemoryProvider(GetStops()),

            };
        }
        private  Features GetStops()
        {
            // Prepare a features variable, and build the data to populate it.
            var features = new Features();
           
        


            // Add each stop as a feature to features.
            foreach (StopViewModel stop in trail.Stops)
            {
                // Get the coordinates for each stop.
                var coordinates = SphericalMercator.FromLonLat(Convert.ToDouble(decimal.Parse(stop.CoordinateX, System.Globalization.CultureInfo.InvariantCulture)), Convert.ToDouble(decimal.Parse(stop.CoordinateY, System.Globalization.CultureInfo.InvariantCulture)));


                // Add the new Feature to Features.
                features.Add(new Feature
                {
                    Geometry = coordinates,
                    ["Label"] = stop.StopID,
                    ["Name"] = stop.StopName,
                });
            }
            // Return the features.
            return features;
        }

    }

}
