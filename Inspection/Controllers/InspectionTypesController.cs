using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Inspection;
using Inspection.Data;

namespace Inspection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InspectionTypesController : ControllerBase
    {
        private readonly DataContext _context;

        public InspectionTypesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/InspectionTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InspectionTypes>>> GetInspectionTypes()
        {
          if (_context.InspectionTypes == null)
          {
              return NotFound();
          }
            return await _context.InspectionTypes.ToListAsync();
        }

        // GET: api/InspectionTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InspectionTypes>> GetInspectionTypes(int id)
        {
          if (_context.InspectionTypes == null)
          {
              return NotFound();
          }
            var inspectionTypes = await _context.InspectionTypes.FindAsync(id);

            if (inspectionTypes == null)
            {
                return NotFound();
            }

            return inspectionTypes;
        }

        // PUT: api/InspectionTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInspectionTypes(int id, InspectionTypes inspectionTypes)
        {
            if (id != inspectionTypes.Id)
            {
                return BadRequest();
            }

            _context.Entry(inspectionTypes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InspectionTypesExists(id))
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

        // POST: api/InspectionTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InspectionTypes>> PostInspectionTypes(InspectionTypes inspectionTypes)
        {
          if (_context.InspectionTypes == null)
          {
              return Problem("Entity set 'DataContext.InspectionTypes'  is null.");
          }
            _context.InspectionTypes.Add(inspectionTypes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInspectionTypes", new { id = inspectionTypes.Id }, inspectionTypes);
        }

        // DELETE: api/InspectionTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInspectionTypes(int id)
        {
            if (_context.InspectionTypes == null)
            {
                return NotFound();
            }
            var inspectionTypes = await _context.InspectionTypes.FindAsync(id);
            if (inspectionTypes == null)
            {
                return NotFound();
            }

            _context.InspectionTypes.Remove(inspectionTypes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InspectionTypesExists(int id)
        {
            return (_context.InspectionTypes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
