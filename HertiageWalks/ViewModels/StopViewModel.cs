using System;
using System.Collections.Generic;
using System.Text;
using HertiageWalks.Model;
using HertiageWalks.Services;
using MvvmHelpers;

namespace HertiageWalks.ViewModel
{
    public class StopViewModel :BaseViewModel
    {
        private StopLocation stop;
        public StopViewModel()
        {

        }
        public StopViewModel(StopLocation stop)
        {
            this.stop = stop;
        }

        public StopLocation Stop
        {
            get { return stop; }
            set { OnPropertyChanged(); }
        }

        public int StopID
        {
            get { return stop.id; }
            set { OnPropertyChanged(); }
        }

        public string StopName
        {
            get { return stop.name; }
            set { OnPropertyChanged(); }
        }

        public string ShortDescription
        {
            get { return stop.short_desc; }
            set { OnPropertyChanged(); }
        }

        public double CoordinateX
        {
            get { return stop.coord_x; }
            set { OnPropertyChanged(); }
        }

        public double CoordinateY
        {
            get { return stop.coord_y; }
            set { OnPropertyChanged(); }
        }

        public string StreetLocation
        {
            get { return stop.street_location; }
            set { OnPropertyChanged(); }
        }

        public string StopImg 
        {
            get { return string.Format(HeritageWalkService.ImgPath, "stops", stop.img); }
            set { OnPropertyChanged(); }
        }



    }
}
