using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using HertiageWalks.ViewModel;
using System.Windows.Input;

namespace HertiageWalks.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TrailViewCell : ViewCell
    {
        public TrailViewCell()
        {
            InitializeComponent();
        }

        #region "Trail BindableProperty"
        public static readonly BindableProperty TrailProperty =
            BindableProperty.Create(
                "Trail",
                typeof(TrailViewModel),
                typeof(TrailViewCell),
                null);
        public TrailViewModel Trail
        {
            get { return (TrailViewModel)GetValue(TrailProperty); }
            set { SetValue(TrailProperty, value); }
        }
        #endregion

        #region ItemTappedCommand BindableProperty
        public static readonly BindableProperty ItemTappedCommandProperty =
            BindableProperty.Create(
                "ItemTappedCommand",
                typeof(ICommand),
                typeof(TrailViewCell),
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
                imgPhoto.Source = Trail.ImgUri;
                lblName.Text = Trail.TrailName;
                lblTime.Text = Trail.Time;
                lblLength.Text = Trail.TrailLength;
            }
        }

        void TrailCell_Tapped(object sender, System.EventArgs e)
        {
            if (ItemTappedCommand != null)
            {
                ItemTappedCommand.Execute(Trail);
            }
        }
    }
}