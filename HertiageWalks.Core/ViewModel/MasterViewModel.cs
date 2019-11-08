using System;
using System.Collections.Generic;
using System.Text;
using HertiageWalks.Core.Model;
using HertiageWalks.Core.Services;
using MvvmHelpers;

namespace HertiageWalks.Core.ViewModel
{
    class MasterViewModel : BaseViewModel
    {
        private List<Trail> trails;
        private List<StopLocation> stops;

        private IList<TrailViewModel> trailViews;

        public HeritageWalkService HeritageWalkService { get; } = new HeritageWalkService();

        public MasterViewModel(int selection)
        {
            LoadDataAsync(selection);
        }

        public IList<TrailViewModel> Trails
        {
            get { return trailViews; }
            set { OnPropertyChanged(); }
        }

        public async void LoadDataAsync(int selection)
        {
            switch (selection)
            {
                case 1:
                    trails = await HeritageWalkService.GetAllTrails();
                    OnPropertyChanged("Trails");
                    break;
                case 2:
                    stops = await HeritageWalkService.GetAllStops();
                    OnPropertyChanged("Stops");
                    break;
                default:
                    break;
            }
            
        }
    }
}
