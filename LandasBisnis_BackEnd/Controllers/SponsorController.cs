using LandasBisnis_BackEnd.Contracts;
using LandasBisnis_BackEnd.Models;
using LandasBisnis_BackEnd.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LandasBisnis_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorController(ISponsorService service) : ControllerBase{
        private readonly ISponsorService _service = service;

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? id){
            var result = await _service.Get(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSponsorContract sponsor){
            var result = await _service.Create(sponsor);
            return CreatedAtAction(nameof(Get), new{id = result?.Id});
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateSponsorContract sponsor, string id){
            if(sponsor == null) return BadRequest(new {Message = "Invalid Data!"});
            var result = await _service.Update(sponsor, id);
            if(result == null) return NotFound(new {Message = "Sponsor not Found!"});
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id){
            var result = await _service.Delete(id);
            if(result == null) return NotFound(new {Message = "Sponsor not Found!"});
            return Ok(new {Message = "Sponsor Deleted!"});
        }
    }
}
