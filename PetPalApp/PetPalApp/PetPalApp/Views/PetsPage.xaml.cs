using PetPalApp.ViewModels;
using Xamarin.Forms;

namespace PetPalApp.Views
{
    public partial class PetsPage : ContentPage
    {
        PetsViewModel _viewModel;

        public PetsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new PetsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
