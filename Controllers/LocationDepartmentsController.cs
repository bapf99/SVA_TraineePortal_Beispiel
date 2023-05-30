using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SVA_TraineePortal.Models;
using SVA_TraineePortal.Models.Contexts;
using SVA_TraineePortal.Models.DTO;

namespace SVA_TraineePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationDepartmentsController : ControllerBase
    {
        private readonly LocationDepartmentContext _context;

        public LocationDepartmentsController(LocationDepartmentContext context)
        {
            _context = context;
        }

        // GET: api/LocationDepartments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LocationDepartmentDTO>>> GetLocationDepartments()
        {
          if (_context.LocationDepartments == null)
          {
              return NotFound();
          }

            Console.WriteLine("Got all LocationDepartments");

            return await _context.LocationDepartments
                .Select(x => DepartmentToDTO(x))
                .ToListAsync();
        }

        // GET: api/LocationDepartments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LocationDepartmentDTO>> GetLocationDepartment(int id)
        {
          if (_context.LocationDepartments == null)
          {
              return NotFound();
          }
            var locationDepartment = await _context.LocationDepartments.FindAsync(id);

            if (locationDepartment == null)
            {
                return NotFound();
            }

            Console.WriteLine($"Got LocationDepartment: {locationDepartment}, {id}");

            return DepartmentToDTO(locationDepartment);
        }

        // PUT: api/LocationDepartments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocationDepartment(int id, LocationDepartmentDTO locationDepartmentDTO)
        {
            if (id != locationDepartmentDTO.Id)
            {
                return BadRequest();
            }

            var locationDepartment = await _context.LocationDepartments.FindAsync(id);
            if (locationDepartment == null)
                return NotFound();

            locationDepartment.DepartmentName = locationDepartmentDTO.DepartmentName;
            locationDepartment.Description = locationDepartmentDTO.Description;
            locationDepartment.CompanyLocationId = locationDepartmentDTO.CompanyLocationId;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!LocationDepartmentExists(id))
            {
                return NotFound();
            }

            Console.WriteLine($"Put LocationDepartment: {locationDepartment}");

            return NoContent();
        }

        // POST: api/LocationDepartments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LocationDepartmentDTO>> CreateLocationDepartment(LocationDepartmentDTO locationDepartmentDTO)
        {
          if (_context.LocationDepartments == null)
          {
              return Problem("Entity set 'LocationDepartmentContext.LocationDepartments'  is null.");
          }


            var locationDepartment = new LocationDepartment(locationDepartmentDTO);

            _context.LocationDepartments.Add(locationDepartment);
            await _context.SaveChangesAsync();

            Console.WriteLine($"Created LocationDepartment: {locationDepartment}");

            return CreatedAtAction(nameof(GetLocationDepartment), new { id = locationDepartment.Id }, DepartmentToDTO(locationDepartment));
        }

        // DELETE: api/LocationDepartments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocationDepartment(int id)
        {
            if (_context.LocationDepartments == null)
            {
                return NotFound();
            }
            var locationDepartment = await _context.LocationDepartments.FindAsync(id);
            if (locationDepartment == null)
            {
                return NotFound();
            }

            _context.LocationDepartments.Remove(locationDepartment);
            await _context.SaveChangesAsync();

            Console.WriteLine($"Deleted LocationDepartment: {locationDepartment}");

            return NoContent();
        }

        private bool LocationDepartmentExists(int id)
        {
            return (_context.LocationDepartments?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        private LocationDepartmentDTO DepartmentToDTO(LocationDepartment locationDepartment)
        {
            return new LocationDepartmentDTO(locationDepartment);
        }
    }
}
