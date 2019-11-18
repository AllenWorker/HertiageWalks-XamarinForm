using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HertiageWalks.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HertiageWalks.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StopViewCell : ViewCell
    {
        public StopViewCell()
        {
            InitializeComponent();
        }

        #region "StopLocation BindableProperty"
        public static readonly BindableProperty StopProperty =
            BindableProperty.Create(
                "StopLocation",
                typeof(StopViewModel),
                typeof(StopViewCell),
                null);
        public StopViewModel StopLocation
        {
            get { return (StopViewModel)GetValue(StopProperty); }
            set { SetValue(StopProperty, value); }
        }
        #endregion

        #region ItemTappedCommand BindableProperty
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create(
                "ItemTappedCommand",
                typeof(ICommand),
                typeof(StopViewCell),
                null);
        public ICommand ItemTappedCommand
        {
            get { return (ICommand)GetValue(ItemTappedCommandProperty); }
            set { SetValue(ItemTappedCommandProperty, value); }
        }
        #endregion
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (BindingContext != null)
            {
                imgPhoto.Source = StopLocation.StopImg;
                lblName.Text = StopLocation.StopName;
                lblstreet_location.Text = StopLocation.StreetLocation;
            }
        }

        void StopCell_Tapped(object sender, System.EventArgs e)
        {
            if (ItemTappedCommand != null)
            {
                ItemTappedCommand.Execute(StopLocation);
            }
        }
    }
}