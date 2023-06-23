using Microsoft.AspNetCore.Mvc;
using TicketTravel.Dto;
using TicketTravel.Interface;
using TicketTravel.Models;

namespace TicketTravel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeTranportation : ControllerBase
    {
        private readonly ITransportationType _transportationTypeRepo;

        public TypeTranportation(ITransportationType transportationType)
        {
            _transportationTypeRepo = transportationType;
        }

        [HttpGet("transportation-types")]
        public IActionResult GetAllTransportationType()
        {
            return Ok(_transportationTypeRepo.GetAllTransportationType());
        }

        [HttpGet("{id}")]
        public IActionResult GetTransportationTypeById([FromQuery]int id)
        {
            var idTransportationExist = _transportationTypeRepo.TransportationTypeGetById(id);
            if(idTransportationExist == null)
            {
                return BadRequest("Id Not Found");
            }

            return Ok(idTransportationExist);
        }

        [HttpPost("create")]
        public IActionResult CreateTransportationType([FromBody] TransportationTypeDto transportationTypeDto)
        {
            var existTransportationType = _transportationTypeRepo.GetAllTransportationType()
                .Where(t => t.TransportationTypeName == transportationTypeDto.TransportationTypeName).FirstOrDefault();

            if(existTransportationType != null)
            {
                return BadRequest("Transportation Type has already exist");
            }

            var createTransportationType = new TransportationType
            {
                TransportationTypeName = transportationTypeDto.TransportationTypeName
            };

            _transportationTypeRepo.Create(createTransportationType);
            return Ok("Created Data Succses!!!");
        }

        [HttpPut("update")]
        public IActionResult UpdateTransportationType([FromQuery] int id, [FromBody] TransportationTypeDto transportationTypeDto)
        {
            var transportationTypeExistById = _transportationTypeRepo.GetAllTransportationType()
                .Where(t => t.Id == id).FirstOrDefault();

            var transportationTypeExistByName = _transportationTypeRepo.GetAllTransportationType().
                Where(t => t.TransportationTypeName == transportationTypeDto.TransportationTypeName).FirstOrDefault();

            if(transportationTypeExistById ==  null)
            {
                return BadRequest("Id Not Found!!!");
            }
            else if(transportationTypeExistByName != null && transportationTypeDto.TransportationTypeName != transportationTypeExistById.TransportationTypeName)
            {
                return BadRequest("Name Has already exist!!!");
            }

            transportationTypeExistById.TransportationTypeName = transportationTypeDto.TransportationTypeName;
            _transportationTypeRepo.Update(transportationTypeExistById);
            return Ok("Sucsess Update Data");
        }

        [HttpDelete("id")]
        public IActionResult DeleteTransportationType([FromQuery]int id)
        {
            var transportationTypeExistById = _transportationTypeRepo.TransportationTypeGetById(id);
            if(transportationTypeExistById == null)
            {
                return BadRequest("Id Not Found!!!");
            }
            _transportationTypeRepo.Delete(id);
            return Ok("Sucses Delete Data");
        }

    }
}
