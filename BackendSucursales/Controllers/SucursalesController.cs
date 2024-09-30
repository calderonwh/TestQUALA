using BackendSucursales.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackendSucursales.DTOs;

namespace BackendSucursales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly ISucursalService _sucursalService;

        public SucursalesController(ISucursalService sucursalService)
        {
            _sucursalService = sucursalService;
        }

        [HttpGet]
        public async Task<ActionResult<List<SucursalDto>>> GetSucursales()
        {
            var sucursales = await _sucursalService.GetSucursalesAsync();
            return Ok(sucursales);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SucursalDto>> GetSucursalById(int id)
        {
            var sucursal = await _sucursalService.GetSucursalByIdAsync(id);
            if (sucursal == null)
                return NotFound();
            return Ok(sucursal);
        }

        [HttpPost]
        public async Task<ActionResult<SucursalDto>> CreateSucursal(SucursalDto sucursalDto)
        {
            var sucursal = await _sucursalService.AddSucursalAsync(sucursalDto);
            return CreatedAtAction(nameof(GetSucursalById), new { id = sucursal.IdSucursal }, sucursal);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SucursalDto>> UpdateSucursal(int id, SucursalDto sucursalDto)
        {
            if (id != sucursalDto.IdSucursal)
                return BadRequest();

            var updatedSucursal = await _sucursalService.UpdateSucursalAsync(sucursalDto);
            return Ok(updatedSucursal);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSucursal(int id)
        {
            var result = await _sucursalService.DeleteSucursalAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }

}
