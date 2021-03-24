using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace PetPalApp.ViewModels
{
    [QueryProperty(nameof(PetId), nameof(PetId))]
    public class PetDetailViewModel : BaseViewModel
    {
        private string petId;
        private string name;
        private DateTime birthDate;
        private string info;
        public string Id { get; set; }

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

        public string PetId
        {
            get
            {
                return petId;
            }
            set
            {
                petId = value;
                LoadPetId(value);
            }
        }

        public async void LoadPetId(string petId)
        {
            try
            {
                var pet = await DataStore.GetPetAsync(petId);
                Id = pet.Id;
                Name = pet.Name;
                BirthDate = pet.BirthDate;
                Info = pet.Info;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Pet");
            }
        }
    }
}
