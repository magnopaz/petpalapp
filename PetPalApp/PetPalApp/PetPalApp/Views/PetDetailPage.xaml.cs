using PetPalApp.ViewModels;
using Xamarin.Forms;

namespace PetPalApp.Views
{
    public partial class PetDetailPage : ContentPage
    {
        public PetDetailPage()
        {
            InitializeComponent();
            BindingContext = new PetDetailViewModel();
        }
    }
}
