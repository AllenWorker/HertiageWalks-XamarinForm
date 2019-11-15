using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using HertiageWalks.Model;
using HertiageWalks.Services;
using MvvmHelpers;

namespace HertiageWalks.ViewModel
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

        public TrailViewModel Trail
        {
            get { return this; }
            set { OnPropertyChanged(); }
        }

        public Trail TrailModel
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

        public string TrailDescription
        {
            get { return trail.description; }
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

