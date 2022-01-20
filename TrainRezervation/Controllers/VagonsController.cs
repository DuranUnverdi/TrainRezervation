using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainRes.Model;
using TrainRes.Repositories;

namespace TrainRes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagonsController : ControllerBase
    {
        private readonly IVagonRepository _vagonRepository;
        public VagonsController(IVagonRepository vagonRepository)
        {
            
            _vagonRepository = vagonRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<Vagon>> GetVagons()
        {
            return await _vagonRepository.Get();
        }
        [HttpPost]
        public async Task<ActionResult<Vagon>> PostVagon([FromBody] Vagon vagon)
        {
            var newTrain = await _vagonRepository.Create(vagon);
            return CreatedAtAction(nameof(GetVagons), new { id = newTrain.Id }, newTrain);
        }
    }
}
