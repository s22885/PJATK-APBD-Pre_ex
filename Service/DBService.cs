using Microsoft.EntityFrameworkCore;
using PreKolos2.DTO;
using PreKolos2.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PreKolos2.Service
{
    public class DBService : IDBService
    {
        private readonly _ContextFireTruck _db;
        public DBService(_ContextFireTruck db)
        {
            _db = db;
        }

        public async Task<bool> AddTruckActionByIdAsync(int IdAction, int IdTruck)
        {
            var count = _db.Actions
                .Where(a => a.IdAction == IdAction)
                .Include(x => x.FireTruckActions).Count();
            if (count >= 3)
            {
                return await Task.FromResult(false);
            }
            var check = await _db.Actions.Where(a => a.IdAction == IdAction).Select(x => x.NeedSpecialEquipment).FirstOrDefaultAsync();
            if (check == null)
            {
                return await Task.FromResult(false);
            }
            var checkTruck = await _db.FireTrucks.Where(a => a.IdFiretruck == IdTruck).Select(x => x.SpecialEquipment).FirstOrDefaultAsync();
            if (checkTruck == null)
            {
                return await Task.FromResult(false);
            }
            var checkTime = _db.Actions.Where(a => a.IdAction == IdAction).Select(x => x.EndTime).FirstOrDefault();
            if (checkTime < System.DateTime.Now)
            {
                return await Task.FromResult(false);
            }

            var res = _db.FireTruckActions.Add(new FireTruckAction
            {
                IdAction = IdAction,
                IdFireTruck = IdTruck,
                AssignmentDate = System.DateTime.Now
            });
            var changesCount = _db.SaveChanges();
            if (changesCount == 0)
            {
                return await Task.FromResult(false);
            }
            return await Task .FromResult(true);
        }

        public async Task<bool> DeleteTruckByIdAsync(int IdTruck)
        {
           var tmp = _db.FireTrucks.Where(e => e.IdFiretruck == IdTruck).FirstOrDefault();
            if (tmp == null) return false;

            _db.Remove(tmp);
            var tmp2 =await _db.SaveChangesAsync();
            return tmp2!=0;
        }

        public async Task<ActionDTO> GetActionByIdAsync(int IdAction)
        {
            var res = _db
                .Actions
                .Where(x => x.IdAction == IdAction)
                .Include(x => x.FireTruckActions).ThenInclude(x => x.IdFireTruckNavigation)
                .Select(x => new ActionDTO
                {
                    IdAction = x.IdAction,
                    StartTime = x.StartTime,
                    EndTime = x.EndTime,
                    NeedSpecialEquipment = false,
                    fireTruckActionDTOs = x.FireTruckActions.OrderBy(y=>y.AssignmentDate)
                    .Select(y => new FireTruckDTO
                    {
                        IdFiretruck = y.IdFireTruckNavigation.IdFiretruck,
                        OperationNumber = y.IdFireTruckNavigation.OperationNumber,
                        SpecialEquipment = y.IdFireTruckNavigation.SpecialEquipment,
                        
                    })
                    .ToList()
                }).SingleOrDefault();

            return res;

            
        }
    }
}
