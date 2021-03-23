using PetPalApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetPalApp.Services
{
    public class MockDataStore : IDataStore<Pet>
    {
        readonly List<Pet> pets;

        public MockDataStore()
        {
            pets = new List<Pet>()
            {
                new Pet { Id = Guid.NewGuid().ToString(), Name = "Nastya", BirthDate = DateTime.Now, Info = "" },
               new Pet { Id = Guid.NewGuid().ToString(), Name = "Mini Piu", BirthDate = DateTime.Now, Info = "" },
               new Pet { Id = Guid.NewGuid().ToString(), Name = "Ninix", BirthDate = DateTime.Now, Info = "" },
            };
        }

        public async Task<bool> AddPetAsync(Pet pet)
        {
            pets.Add(pet);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdatePetAsync(Pet pet)
        {
            var oldItem = pets.Where((Pet arg) => arg.Id == pet.Id).FirstOrDefault();
            pets.Remove(oldItem);
            pets.Add(pet);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeletePetAsync(string id)
        {
            var oldItem = pets.Where((Pet arg) => arg.Id == id).FirstOrDefault();
            pets.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Pet> GetPetAsync(string id)
        {
            return await Task.FromResult(pets.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Pet>> GetPetsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(pets);
        }
    }
}
