using PetPalApp.Models;
using System;
using Xamarin.Forms;

namespace PetPalApp.ViewModels
{
    public class NewPetViewModel : BaseViewModel
    {
        private string name;
        private string info;
        private DateTime birthDate;

        public NewPetViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(info);
        }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public DateTime BirthDate
        {
            get => birthDate;
            set => SetProperty(ref birthDate, value);
        }

        public string Info
        {
            get => info;
            set => SetProperty(ref info, value);
        }

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Pet newPet = new Pet()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Info = Info,
                BirthDate = BirthDate
            };

            await DataStore.AddPetAsync(newPet);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
