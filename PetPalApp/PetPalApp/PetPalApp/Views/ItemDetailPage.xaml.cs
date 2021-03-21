using PetPalApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PetPalApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}