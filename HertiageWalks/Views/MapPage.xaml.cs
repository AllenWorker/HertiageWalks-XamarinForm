using Android.Widget;
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
using System.Globalization;
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

        private TrailViewModel trail;

        public MapPage(TrailViewModel trailViewModel)
        {
           
            InitializeComponent();
            trail = trailViewModel;
            mapView.Map = CreateMap();
            mapView.Info += StopInfo;


        }


        /// <summary>
        /// press on point to view stop
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void StopInfo(object sender, MapInfoEventArgs e)
        {
            if (e.MapInfo.Feature != null)
            {
                //Console.WriteLine(e.MapInfo.Feature?["Name"]?.ToString() + e.MapInfo.Feature?["StreetName"]?.ToString());
                Device.BeginInvokeOnMainThread(async () => {
                    await DisplayAlert(e.MapInfo.Feature?["Name"]?.ToString(), e.MapInfo.Feature?["StreetName"]?.ToString() + ". " + e.MapInfo.Feature?["desc"]?.ToString(), "OK");
                });
            }
        }

      


        /// <summary>
        /// creates the openstreetmap & point layer AKA stop layer
        /// </summary>
        /// <returns></returns>
        public Mapsui.Map CreateMap()
        {
            map = new Map();
            map.Layers.Add(OpenStreetMap.CreateTileLayer());
            map.Layers.Add(CreatePointLayer());


            return map;
        }

        /// <summary>
        /// create the point layer
        /// </summary>
        /// <returns></returns>
        private  MemoryLayer CreatePointLayer()
        {
            return new MemoryLayer
            {
                Name = "Points",
                IsMapInfoLayer = true,
                DataSource = new MemoryProvider(GetStops()),

            };
        }

        /// <summary>
        ///loops through stop to create a point on the layer above 
        /// </summary>
        /// <returns></returns>
        private  Features GetStops()
        {
            // Prepare a features variable, and build the data to populate it.
            var features = new Features();

            
            
            // Add each stop as a feature to features.
            foreach (StopViewModel stop in trail.Stops)
            {
                

                List<Mapsui.Styles.Style> styles = new List<Mapsui.Styles.Style>();
                styles.Add(new LabelStyle { Text = stop.StopName });


               var coordinates = SphericalMercator.FromLonLat(stop.CoordinateY, stop.CoordinateX);



                // Add the new Feature to Features.
                features.Add(new Feature
                {
                   Geometry = coordinates,

                    Styles = styles.ToArray(),
                  


                    ["Label"] = stop.StopID,
                    ["Name"] = stop.StopName,
                    ["StreetName"] = stop.StreetLocation, 
                    ["desc"] = stop.ShortDescription,

                });
            }
            // Return the features.
            return features;
        }

    }

}
