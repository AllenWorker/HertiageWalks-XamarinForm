using System;
using System.Collections.Generic;
using System.Text;
using HertiageWalks.Core.Model;
using MvvmHelpers;

namespace HertiageWalks.Core.ViewModel
{
    public class StopViewModel :BaseViewModel
    {
        private StopLocation stop;
        private List<StopLocation> stops;

        public int StopId
        {
            get { return stop.id; }
            set { OnPropertyChanged(); }
        }

        public string StopName
        {
            get { return stop.name; }
            set { OnPropertyChanged(); }
        }

        public string StopImage
        {
            get { return stop.img; }
            set { OnPropertyChanged(); }
        }

        public string StopStreetlocation
        {
            get { return stop.street_location; }
            set { OnPropertyChanged(); }
        }

        public string StopShortDesc
        {
            get { return stop.short_desc; }
            set { OnPropertyChanged(); }
        }

        public string StopLongDesc
        {
            get { return stop.full_desc; }
            set { OnPropertyChanged(); }
        }
    }
}
