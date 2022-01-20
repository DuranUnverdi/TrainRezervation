using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainRes.Model;
using TrainRes.Repositories;

namespace TrainRes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainsController : ControllerBase
    {
        private readonly ITrainRepository _trainRepository;
        

        public TrainsController(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
            
        }
        [Route("get")]
        [HttpGet]
        public async Task<IEnumerable<Train>> GetTrains()
        {
            return await _trainRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Train>> GetTrain(int id)
        {
           return await _trainRepository.Get(id);
        }
        [HttpPost]
        public async Task<ActionResult<Train>> PostTrain([FromBody] Train train)
        {
            var newTrain = await _trainRepository.Create(train);
            return CreatedAtAction(nameof(GetTrains), new { id = newTrain.Id }, newTrain);
        }
        [Route("ress")]
        [HttpPost]
        public ActionResult<ResOutModel> Reservation(ResModel model)
        {
            ResOutModel outModel = _trainRepository.TryRes(model);
            return outModel;
        }
    }
}
