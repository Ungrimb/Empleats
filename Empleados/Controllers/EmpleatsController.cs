using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Empleados.Models;
using Empleados.Data;

namespace Empleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleatsController : ControllerBase
    {
        private readonly EmpleatContext _context;

        public EmpleatsController(EmpleatContext context)
        {
            _context = context;
        }

        // GET: api/Empleats
        [HttpGet]
        /*public String GetEmpleats()
        {

            return "Hola Mundo";

        }

        // GET: api/Empleats/Pedro
        [HttpGet("{Name}")]
        public String GetEmpleats(String Name)
        {
            String retorno = "Hola " + Name;
            return retorno;
        }*/
        public async Task<ActionResult<IEnumerable<Empleat>>> GetEmpleats()
        {
            return await _context.Empleats.ToListAsync();
        }

        // GET: api/Empleats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleat>> GetEmpleat(long id)
        {
            var empleat = await _context.Empleats.FindAsync(id);

            if (empleat == null)
            {
                return NotFound();
            }

            return empleat;
        }

        // PUT: api/Empleats/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleat(long id, Empleat empleat)
        {
            if (id != empleat.Id)
            {
                return BadRequest();
            }

            _context.Entry(empleat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleatExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Empleats
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Empleat>> PostEmpleat(Empleat empleat)
        {
            _context.Empleats.Add(empleat);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpleat", new { id = empleat.Id }, empleat);
        }

        // DELETE: api/Empleats/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Empleat>> DeleteEmpleat(long id)
        {
            var empleat = await _context.Empleats.FindAsync(id);
            if (empleat == null)
            {
                return NotFound();
            }

            _context.Empleats.Remove(empleat);
            await _context.SaveChangesAsync();

            return empleat;
        }

        private bool EmpleatExists(long id)
        {
            return _context.Empleats.Any(e => e.Id == id);
        }
    }
}
