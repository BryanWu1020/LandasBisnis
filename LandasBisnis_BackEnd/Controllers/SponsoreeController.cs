using System.Runtime.CompilerServices;
using LandasBisnis_BackEnd.Contracts;
using LandasBisnis_BackEnd.Models;
using LandasBisnis_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace LandasBisnis_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsoreeController(ISponsoreeService service) : ControllerBase{
        private readonly ISponsoreeService _service = service;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? id){
            var result = await _service.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSponsoreeContract sponsoree){
            var result = await _service.Create(sponsoree);
            return CreatedAtAction(nameof(Get), new{id = result?.Id});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateSponsoreeContract sponsoree, string id){
            if(sponsoree == null) return BadRequest(new {Message = "Invalid Data!"});
            var result = await _service.Update(sponsoree, id);
            if(result == null) return NotFound(new {Message = "Sponsoree Not Found!"});
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id){
            var result = await _service.Delete(id);
            if(result == null) return NotFound(new {Message = "Sponsoree Not Found!"});
            return Ok(new {Message = "Sponsoree Deleted!"});
        }
    }
}
