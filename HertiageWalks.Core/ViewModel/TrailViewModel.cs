using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using HertiageWalks.Core.Model;
using HertiageWalks.Core.Services;
using MvvmHelpers;

namespace HertiageWalks.Core.ViewModel
{
    public class TrailViewModel : BaseViewModel
    {

        private Trail trail;
        private List<StopLocation> stops;
        private IList<StopViewModel> stopViews;

        public HeritageWalkService HeritageWalkService { get; } = new HeritageWalkService();

        public TrailViewModel()
        {

        }

        public TrailViewModel(Trail trail)
        {
            this.trail = trail;
        }

        public Trail Trail
        {
            get { return trail; }
            set { OnPropertyChanged(); }
        }
        
        public int TrailID
        {
            get { return trail.id; }
            set { OnPropertyChanged(); }
        }

        public string TrailName
        {
            get { return trail.name; }
            set { OnPropertyChanged(); }
        }

        public string Time
        {
            get { return trail.time; }
            set { OnPropertyChanged(); }
        }

        public string TrailLength
        {
            get { return trail.length; }
            set { OnPropertyChanged(); }
        }

        public string ImgUri
        {
            get { return string.Format(HeritageWalkService.ImgPath, "trails", trail.img); }
            set { OnPropertyChanged(); }
        }

        public IList<StopViewModel> Stops
        {
            get { return stopViews; }
            set { OnPropertyChanged(); }
        }


        public async void LoadTrailStopAsync()
        {
            stopViews = new ObservableRangeCollection<StopViewModel>();
            stops = await HeritageWalkService.GetTrailStops(trail.id);
            foreach (StopLocation stop in stops)
            {
                stopViews.Add(new StopViewModel(stop));
            }
            OnPropertyChanged("Stops");
        }



    }
}

