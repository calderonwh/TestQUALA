using BackendSucursales.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackendSucursales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        private readonly DbaQualaContext _context;

        public MonedaController(DbaQualaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moneda>>> GetMonedas()
        {
            var monedas = await _context.Monedas.ToListAsync();
            return Ok(monedas);
        }
    }
}
