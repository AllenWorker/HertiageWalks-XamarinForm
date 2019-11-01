using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HertiageWalks.NavHamburger
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HamburgerMenuMaster : ContentPage
    {
        public ListView ListView;

        public HamburgerMenuMaster()
        {
            InitializeComponent();

            BindingContext = new HamburgerMenuMasterViewModel();
            ListView = MenuItemsListView;
        }

        class HamburgerMenuMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HamburgerMenuMenuItem> MenuItems { get; set; }
            
            public HamburgerMenuMasterViewModel()
            {
                MenuItems = new ObservableCollection<HamburgerMenuMenuItem>(new[]
                {
                    new HamburgerMenuMenuItem { Id = 0, Title = "Home" , TargetType = typeof(MainPage) },
                    new HamburgerMenuMenuItem { Id = 1, Title = "Help" , TargetType = typeof(InfoPage)},
                    new HamburgerMenuMenuItem { Id = 2, Title = "something" , TargetType = typeof(MainPage)},
                
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}