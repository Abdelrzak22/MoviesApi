using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using WebApplication2.Dto;
using WebApplication2.models;
using WebApplication2.services;


namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenersController : ControllerBase
    {
        private readonly IGenerservices _generservices;
        public GenersController(IGenerservices generservices)
        {
            _generservices=generservices;
        }

        

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var geners = await _generservices.getall();
            return Ok(geners);
        }


        [HttpPost]

        public async Task<IActionResult> createGenre(CreateGenredto dto)
        {
            var gener= new Gener { Name=dto.Name };
            await _generservices.add(gener);
            
            return Ok(gener);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> updateall(CreateGenredto dto, byte id)
        {
            var gener =await _generservices.getbyid(id);
            if (gener is null)
                return NotFound("the id is not founded");
            gener.Name = dto.Name;
            _generservices.update(gener);   
            return Ok(gener);

           
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> delete( byte id)
        {
            var gener = await _generservices.getbyid(id);
            if (gener is null)
                return NotFound("the id is not founded");
            _generservices.delete(gener);   
            return Ok(gener);


        }



    }
}
