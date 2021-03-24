using PetPalApp.Models;
using PetPalApp.ViewModels;
using Xamarin.Forms;

namespace PetPalApp.Views
{
    public partial class NewPetPage : ContentPage
    {
        public Pet Pet { get; set; }

        public NewPetPage()
        {
            InitializeComponent();
            BindingContext = new NewPetViewModel();
        }
    }
}
