using System;
using System.Collections.Generic;
using System.Text;
using HertiageWalks.Core.Model;
using HertiageWalks.Core.Services;
using MvvmHelpers;

namespace HertiageWalks.Core.ViewModel
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

        public string CoordinateX
        {
            get { return stop.coord_x; }
            set { OnPropertyChanged(); }
        }

        public string CoordinateY
        {
            get { return stop.coord_y; }
            set { OnPropertyChanged(); }
        }

        public string StopImg 
        {
            get { return string.Format(HeritageWalkService.ImgPath, "stops", stop.img); }
            set { OnPropertyChanged(); }
        }



    }
}
