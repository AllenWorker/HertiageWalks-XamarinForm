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

        public TrailViewModel()
        {
            
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





    }
}

