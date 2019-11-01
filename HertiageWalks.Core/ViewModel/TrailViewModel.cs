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

        public string TrailImage
        {
            get { return trail.img; }
            set { OnPropertyChanged(); }
        }

        public string TrailDistance
        {
            get { return trail.length; }
            set { OnPropertyChanged(); }
        }

        public string TrailTime
        {
            get { return trail.time; }
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
        }
        
    }
}
