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

        private List<Trail> trails;
        public HeritageWalkService HeritageWalkService { get; } = new HeritageWalkService();

        public TrailViewModel()
        {
            LoadDataAsync();
        }





        public List<Trail> Trails
        {
            get { return trails; }
            set { OnPropertyChanged(); }
        }

        public async void LoadDataAsync()
        {
            trails = await HeritageWalkService.GetAllTrails();
            OnPropertyChanged("Trails");
        }

    }
}

