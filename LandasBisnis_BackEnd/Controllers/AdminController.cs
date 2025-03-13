using LandasBisnis_BackEnd.Contracts;
using LandasBisnis_BackEnd.Models;
using LandasBisnis_BackEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LandasBisnis_BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IAdminService service) : ControllerBase{
        private readonly IAdminService _service = service;

        [HttpGet("{id}")]
        [Authorize("canManageAdmins")]
        public async Task<IActionResult> Get(string? id){
            var result = await _service.Get(id);
            return Ok(result);
        }

        [HttpPost]
        [Authorize("Admin")]
        public async Task<IActionResult> Create([FromBody] CreateAdminContract admin){
            if(admin == null) return BadRequest(new {Message = "Admin not Found!"});
            var result = await _service.Create(admin);
            return CreatedAtAction(nameof(Get), new{id = result?.Id});
        }

        [HttpPut("{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateAdminContract admin, string id){
            if(admin == null) return BadRequest(new {Message = "Invalid Data!"});
            var result = await _service.Update(admin, id);
            if(result == null) return NotFound(new {Message = "Admin not Found!"});
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize("Admin")]
        public async Task<IActionResult> Delete(string id){
            var result = await _service.Delete(id);
            if(result == null) return NotFound(new {Message = "Admin not Found!"});
            return Ok(new {Message = "Admin Deleted!"});
        }
    }
}
