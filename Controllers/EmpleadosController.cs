using Api_Empresa.Data;
using Api_Empresa.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Empresa.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : Controller
    {
        private readonly AppDbContext _db;
        public EmpleadosController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpleados()
        {
            var lista = await _db.Empleados.ToListAsync();
            return Ok(lista);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpleados(int id)
        {
            var obj = await _db.Empleados.FindAsync(id);

            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);

        }

        [HttpPost]
        public async Task<ActionResult> PostEmpleados([FromBody] Empleados empleados)
        {
            if(empleados == null)
            {
                return BadRequest(ModelState); // Envia todos los errores que encuentre
            }

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _db.AddAsync(empleados);
            await _db.SaveChangesAsync(); // Guarda los cambios

            //return CreatedAtRoute("GetEmpleados", new { id = empleados.idEmpleado }, empleados);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleados(int id, Empleados empleados)
        {
            if(id != empleados.idEmpleado)
            {
                return BadRequest(); 
            }

            _db.Entry(empleados).State = EntityState.Modified;
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!(_db.Empleados.Any(c => c.idEmpleado == id)))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleados(int id)
        {
            var empleados = await _db.Empleados.FindAsync(id);

            if(empleados == null)
            {
                return NotFound();
            }

            _db.Empleados.Remove(empleados);
            await _db.SaveChangesAsync();

            return Ok();
        }

    }
}
