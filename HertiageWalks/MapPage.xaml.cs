﻿using Mapsui;
using Mapsui.Layers;
using Mapsui.Projection;
using Mapsui.Providers;
using Mapsui.Styles;
using Mapsui.UI;
using Mapsui.Utilities;
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
        private Map map;


        public MapPage ()
		{
			InitializeComponent ();

            var map = new Mapsui.Map();

            mapView.Map = CreateMap();


            mapView.Map.Info += StopInfo;
        }

        public void StopInfo(object sender, MapInfoEventArgs e)
        {

          

        }

        public Mapsui.Map CreateMap()
        {
            map = new Map();
            map.Layers.Add(OpenStreetMap.CreateTileLayer());

            // Get the lon lat coordinates from somewhere (Mapsui can not help you there)
            var center = new Mapsui.Geometries.Point(115.85713, -31.95496);
            // OSM uses spherical mercator coordinates. So transform the lon lat coordinates to spherical mercator
            var sphericalMercatorCoordinate = SphericalMercator.FromLonLat(center.X, center.Y);
            // Set the center of the viewport to the coordinate. The UI will refresh automatically
            map.NavigateTo(sphericalMercatorCoordinate);
            // Additionally you might want to set the resolution, this could depend on your specific purpose
            map.NavigateTo(map.Resolutions[7]);
            //LoadPoints();

            return map;
        }
        /* private void LoadPoints()
        {
            // MapControl mapControl = null;// Get MapControl element here.
            //var map = new Map();
            // map.Layers.Add(OpenStreetMap.CreateTileLayer());

            var bitmap = ((BitmapDrawable)con.Resources.GetDrawable(Resource.Drawable.info, con.Theme)).Bitmap;

            Stream stream = new MemoryStream();
            bitmap.Compress(Android.Graphics.Bitmap.CompressFormat.Png, 0, stream);
            map.Layers.Add(new MemoryLayer
            {
                Style = null,
                // Get all the stops as features and set it as the data source.
                DataSource = new MemoryProvider(GetStops())
            });
            map.InfoLayers.Add(new MemoryLayer
            {
                Name = "StopInfo",
                DataSource = new MemoryProvider(GetStops()),
                Style = new SymbolStyle
                {
                    BitmapId = BitmapRegistry.Instance.Register(stream),
                    SymbolOffset = new Offset(0f, 0f),

                    SymbolScale = 0.3
                }
            });
        }

       private static Features GetStops()
        {
            // Prepare a features variable, and build the data to populate it.
            var features = new Features();
            //    List<trails> list = new List<trail>();


            // Add each stop as a feature to features.
            foreach (var stop in list)
            {
                // Get the coordinates for each stop.
                var coordinates = SphericalMercator.FromLonLat(stop.X, stop.Y);
                List<Style> styles = new List<Style>();

                // Styles are usefull for adding a group of elements to the map, you can add more than a label if you like.
                styles.Add(new LabelStyle { Text = stop.Name });

                // Add the new Feature to Features.
                features.Add(new Feature
                {
                    Geometry = coordinates,
                    ["Label"] = stop.Name,
                    Styles = styles.ToArray()
                });
            }
            // Return the features.
            return features;
        }*/
    }
}