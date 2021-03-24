using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetPalApp.Services
{
    public interface IPetData<T>
    {
        Task<bool> AddPetAsync(T pet);
        Task<bool> UpdatePetAsync(T pet);
        Task<bool> DeletePetAsync(string id);
        Task<T> GetPetAsync(string id);
        Task<IEnumerable<T>> GetPetsAsync(bool forceRefresh = false);
    }
}
