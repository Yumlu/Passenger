using Microsoft.AspNetCore.Mvc;
using Passenger.API.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Passenger.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassengerController : ControllerBase
    {
        private readonly IPassengerRespository _passengerRespository;

        public PassengerController(IPassengerRespository passengerRespository)
        {
            _passengerRespository = passengerRespository;
        }

        [HttpGet]
        public async Task<IList<Passenger.API.Model.Passenger>> Get()
        {
            return await _passengerRespository.Get();
        }

        [HttpGet("{id}")]
        public async Task<Passenger.API.Model.Passenger> GetById(Guid id)
        {
            return await _passengerRespository.GetById(id);
        }

        [HttpPost]
        public async Task Create(Passenger.API.Model.Passenger data)
        {
            await _passengerRespository.Create(data);
        }

        [HttpPut]
        public async Task<ActionResult> Update(Passenger.API.Model.Passenger data)
        {
            try
            {
                await _passengerRespository.Update(data);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _passengerRespository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}