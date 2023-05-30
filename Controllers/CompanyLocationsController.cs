using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SVA_TraineePortal.Models;
using SVA_TraineePortal.Models.DTO;

namespace SVA_TraineePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyLocationsController : ControllerBase
    {
        private readonly CompanyLocationContext _context;

        public CompanyLocationsController(CompanyLocationContext context)
        {
            _context = context;
        }

        // GET: api/CompanyLocations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyLocationDTO>>> GetCompanyLocations()
        {
            Console.WriteLine("Got all CompanyLocations!");
            return await _context.CompanyLocations.Select(x => LocationToDTO(x))
                .ToListAsync();
        }

        // GET: api/CompanyLocations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyLocationDTO>> GetCompanyLocation(int id)
        {
          if (_context.CompanyLocations == null)
          {
              return NotFound();
          }
            var companyLocation = await _context.CompanyLocations.FindAsync(id);

            if (companyLocation == null)
            {
                return NotFound();
            }

            Console.WriteLine($"Got: {companyLocation}, {id}");

            return LocationToDTO(companyLocation);
        }

        // PUT: api/CompanyLocations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyLocation(int id, CompanyLocationDTO companyLocationDTO)
        {
            if (id != companyLocationDTO.Id)
            {
                return BadRequest();
            }

            //_context.Entry(companyLocationDTO).State = EntityState.Modified;

            var companyLocation = await _context.CompanyLocations.FindAsync(id);
            if(companyLocation == null)
            {
                return NotFound();
            }

            companyLocation.LocationName = companyLocationDTO.LocationName;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!CompanyLocationExists(id))
            {
                return NotFound();
            }

            Console.WriteLine($"Put: {companyLocation}");

            return NoContent();
        }

        // POST: api/CompanyLocations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CompanyLocationDTO>> CreateCompanyLocation(CompanyLocationDTO companyLocationDTO)
        {
          if (_context.CompanyLocations == null)
          {
              return Problem("Entity set 'CompanyLocationContext.CompanyLocations'  is null.");
          }
            var companyLocation = new CompanyLocation(companyLocationDTO);
            
            _context.CompanyLocations.Add(companyLocation);
            await _context.SaveChangesAsync();

            Console.WriteLine($"Created: {companyLocation}");

            return CreatedAtAction(nameof(GetCompanyLocation), new { id = companyLocation.Id }, companyLocation);
        }

        // DELETE: api/CompanyLocations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyLocationDTO(int id)
        {
            if (_context.CompanyLocations == null)
            {
                return NotFound();
            }
            var companyLocation = await _context.CompanyLocations.FindAsync(id);
            if (companyLocation == null)
            {
                return NotFound();
            }

            _context.CompanyLocations.Remove(companyLocation);
            await _context.SaveChangesAsync();

            Console.WriteLine($"Deleted: {companyLocation}");

            return NoContent();
        }

        private bool CompanyLocationExists(int id)
        {
            return (_context.CompanyLocations?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private static CompanyLocationDTO LocationToDTO(CompanyLocation companyLocation)
        {
            return new CompanyLocationDTO(companyLocation);
        }
    }
}
