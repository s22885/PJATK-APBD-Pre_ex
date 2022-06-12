using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PreKolos2.Service;
using System.Threading.Tasks;

namespace PreKolos2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FireController : ControllerBase
    {
        private readonly IDBService _iDBService;
        public FireController(IDBService dBService)
        {
            _iDBService = dBService;
        }
        [HttpDelete("{IdTruck}")]
        public async Task<IActionResult> Delete(int IdTruck)
        {
            var res=await _iDBService.DeleteTruckByIdAsync(IdTruck);
            if (res == true) return Ok();
            return BadRequest();
        }
        [HttpGet("{IdAction}")]
        public async Task<IActionResult> GetActionById(int IdAction)
        {
            var res = await _iDBService.GetActionByIdAsync(IdAction);
            return Ok(res);
        }

        [HttpPost("{IdAction},{IdTruck}")]
        public async Task<IActionResult> AddTruckToActionById(int IdAction, int IdTruck)
        {
            var res = await _iDBService.AddTruckActionByIdAsync(IdAction, IdTruck);
            if (res == false)
            {
                return BadRequest();
            }
            return Ok();

        }
    }
}
