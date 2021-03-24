using PetPalApp.Models;
using PetPalApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PetPalApp.ViewModels
{
    public class PetsViewModel : BaseViewModel
    {
        private Pet _selectedPet;

        public ObservableCollection<Pet> Pets { get; }
        public Command LoadPetsCommand { get; }
        public Command AddPetCommand { get; }
        public Command<Pet> PetTapped { get; }

        public PetsViewModel()
        {
            Title = "Pets";
            Pets = new ObservableCollection<Pet>();
            LoadPetsCommand = new Command(async () => await ExecuteLoadPetsCommand());

            PetTapped = new Command<Pet>(OnPetSelected);

            AddPetCommand = new Command(OnAddPet);
        }

        async Task ExecuteLoadPetsCommand()
        {
            IsBusy = true;

            try
            {
                Pets.Clear();
                var pets = await DataStore.GetPetsAsync(true);
                foreach (var pet in pets)
                {
                    Pets.Add(pet);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedPet = null;
        }

        public Pet SelectedPet
        {
            get => _selectedPet;
            set
            {
                SetProperty(ref _selectedPet, value);
                OnPetSelected(value);
            }
        }

        private async void OnAddPet(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewPetPage));
        }

        async void OnPetSelected(Pet pet)
        {
            if (pet == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(PetDetailPage)}?{nameof(PetDetailViewModel.PetId)}={pet.Id}");
        }
    }
}
