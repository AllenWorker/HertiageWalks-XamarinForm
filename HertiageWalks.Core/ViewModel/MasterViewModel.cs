using System;
using System.Collections.Generic;
using System.Text;
using HertiageWalks.Core.Model;
using HertiageWalks.Core.Services;
using MvvmHelpers;

namespace HertiageWalks.Core.ViewModel
{
    public class MasterViewModel : BaseViewModel
    {
        private List<Trail> trails;
        private List<StopLocation> stops;

        private IList<TrailViewModel> trailViews;
        private IList<StopViewModel> stopViews;

        public HeritageWalkService HeritageWalkService { get; } = new HeritageWalkService();

        public MasterViewModel()
        {
            
        }
        public MasterViewModel(int selection)
        {
            LoadDataAsync(selection);
        }

        public IList<TrailViewModel> Trails
        {
            get { return trailViews; }
            set { OnPropertyChanged(); }
        }

        public IList<StopViewModel> Stops
        {
            get { return stopViews; }
            set { OnPropertyChanged(); }
        }

        public async void LoadDataAsync(int selection)
        {
            switch (selection)
            {
                case 1:
                    trailViews = new ObservableRangeCollection<TrailViewModel>();
                    trails = await HeritageWalkService.GetAllTrails();
                    foreach (Trail trail in trails)
                    {
                        trailViews.Add(new TrailViewModel(trail));
                    }
                    OnPropertyChanged("Trails");
                    break;
                case 2:
                    stopViews = new ObservableRangeCollection<StopViewModel>();
                    stops = await HeritageWalkService.GetAllStops();
                    foreach(StopLocation stop in stops)
                    {
                        stopViews.Add(new StopViewModel(stop));
                    }
                    OnPropertyChanged("Stops");
                    break;
                default:
                    break;
            }
            
        }
    }
}
