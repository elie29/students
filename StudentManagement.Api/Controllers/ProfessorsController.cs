using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Api.Data;
using StudentManagement.Api.Models;

namespace StudentManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorsController : ControllerBase
    {
        private readonly StudentDbContext _context;

        public ProfessorsController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: api/Professors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Professor>>> GetProfessors()
        {
            return await _context.Professors.ToListAsync();
        }

        // GET: api/Professors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
            var professor = await _context.Professors.FindAsync(id);

            if (professor == null)
            {
                return NotFound();
            }

            return professor;
        }

        // POST: api/Professors
        [HttpPost]
        public async Task<ActionResult<Professor>> CreateProfessor(Professor professor)
        {
            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfessor), new { id = professor.Id }, professor);
        }

        // PUT: api/Professors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfessor(int id, Professor professor)
        {
            if (id != professor.Id)
            {
                return BadRequest();
            }

            professor.UpdatedAt = DateTime.UtcNow;
            _context.Entry(professor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProfessorExists(id))
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

        // DELETE: api/Professors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessor(int id)
        {
            var professor = await _context.Professors.FindAsync(id);
            if (professor == null)
            {
                return NotFound();
            }

            _context.Professors.Remove(professor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProfessorExists(int id)
        {
            return _context.Professors.Any(e => e.Id == id);
        }
    }
}