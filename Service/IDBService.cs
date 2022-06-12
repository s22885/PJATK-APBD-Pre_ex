using PreKolos2.DTO;
using PreKolos2.Entities;
using System.Threading.Tasks;

namespace PreKolos2.Service
{
    public interface IDBService
    {
         Task<ActionDTO> GetActionByIdAsync(int IdAction);
         Task<bool> AddTruckActionByIdAsync(int IdAction, int IdTruck);
        Task<bool> DeleteTruckByIdAsync(int IdTruck);

    }
}
