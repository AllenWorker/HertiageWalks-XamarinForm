using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using HertiageWalks.Model;
using HertiageWalks.Services;
using MvvmHelpers;
using HertiageWalks;
using Xamarin.Forms;
using System.Linq;

namespace HertiageWalks.ViewModel
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
            //NavigationPage page = HertiageWalks.Views.MainPage;
        }
        public MasterViewModel(int selection)
        {
            LoadDataAsync(selection);

            ItemTappedCommand = new Command((obj) =>
            {
                TrailViewModel trail = obj as TrailViewModel;

                var trailViews = Trails
                                .Where(d => d.TrailID == trail.TrailID)
                                .Select(d => d)
                                .Single();
                var mainPage = App.Current.MainPage;
                var navgation = mainPage.Navigation;
                navgation.PushAsync(new Views.TrailPage(trailViews));
            });
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

        public ICommand ItemTappedCommand { get; private set; }

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
