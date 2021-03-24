using PetPalApp.Views;
using System;
using Xamarin.Forms;

namespace PetPalApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PetDetailPage), typeof(PetDetailPage));
            Routing.RegisterRoute(nameof(NewPetPage), typeof(NewPetPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
