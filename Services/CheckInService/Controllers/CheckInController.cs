using Microsoft.AspNetCore.Mvc;
using CheckInService.Models;
using CheckInService.Data;
using Microsoft.EntityFrameworkCore;

namespace CheckInService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CheckInController : ControllerBase
    {
        private readonly CheckInDbContext _context;

        public CheckInController(CheckInDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CheckIn>>> GetAll()
        {
            return await _context.CheckIns.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CheckIn>> GetById(int id)
        {
            var checkIn = await _context.CheckIns.FindAsync(id);
            if (checkIn == null) return NotFound();
            return checkIn;
        }

        [HttpPost]
        public async Task<ActionResult<CheckIn>> Create(CheckIn checkIn)
        {
            _context.CheckIns.Add(checkIn);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = checkIn.Id }, checkIn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CheckIn checkIn)
        {
            if (id != checkIn.Id) return BadRequest();

            _context.Entry(checkIn).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var checkIn = await _context.CheckIns.FindAsync(id);
            if (checkIn == null) return NotFound();

            _context.CheckIns.Remove(checkIn);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
