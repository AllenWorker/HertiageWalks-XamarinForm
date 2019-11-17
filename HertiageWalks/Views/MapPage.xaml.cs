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


        public List<StopLocation> list = new List<StopLocation>();

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
        async void StopInfo(object sender, MapInfoEventArgs e)
        {
            if (e.MapInfo.Feature != null)
            {
                await DisplayAlert(e.MapInfo.Feature?["Name"]?.ToString(), e.MapInfo.Feature?["StreetName"]?.ToString() , "OK");
               

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
                // Get the coordinates for each stop.

                List<Mapsui.Styles.Style> styles = new List<Mapsui.Styles.Style>();
                styles.Add(new LabelStyle { Text = stop.StopName });

              //  var coordinates = SphericalMercator.FromLonLat(stop.CoordinateX, stop.CoordinateY);



                // Add the new Feature to Features.
                features.Add(new Feature
                {
                 //   Geometry = coordinates,

                    Styles = styles.ToArray(),
                  


                    ["Label"] = stop.StopID,
                    ["Name"] = stop.StopName,
                    ["StreetName"] = stop.StreetLocation, 

                });
            }
            // Return the features.
            return features;
        }

    }

}
