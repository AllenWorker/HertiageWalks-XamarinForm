using System;
using System.Collections.Generic;
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
        private List<Trail> trails;
        public HeritageWalkService HeritageWalkService { get; } = new HeritageWalkService();

        public TrailViewModel()
        {
            trails = new List<Trail>();
            LoadData();
            
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

        public List<Trail> Trails 
        {
            get { return trails; }
            set { OnPropertyChanged(); }
        }

        public async void LoadData()
        {
            trails = await HeritageWalkService.GetAllTrails();
            trail = trails[0];
            OnPropertyChanged();
        }
        
    }
}
