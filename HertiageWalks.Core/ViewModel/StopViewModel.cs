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
        private List<StopLocation> stops;
        public HeritageWalkService HeritageWalkService { get; } = new HeritageWalkService();
        public StopViewModel()
        {
            LoadDataAsync();
       
        }

        public List<StopLocation> Stops
        {
            get { return stops; }
            set { OnPropertyChanged(); }
        }

        public async void LoadDataAsync()
        {
            stops = await HeritageWalkService.GetAllStops();
            OnPropertyChanged("Stops");
        }
    }
}
