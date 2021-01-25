using BugtrackerBackend.Data;
using BugtrackerBackend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BugtrackerBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BugController : ControllerBase
    {
        private BugtrackerContext _context;

        public BugController(BugtrackerContext context)
        {
            _context = context;
        }

        // GET: api/Bug
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bug>>> GetAllBugs()
        {
            var bug = await _context.Bug.ToListAsync();

            return bug;
        }

        // GET: api/Bug/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Bug>> GetBug(int id)
        {
            var bug = await _context.Bug.FindAsync(id);

            if (bug == null)
            {
                return NotFound();
            }

            return bug;
        }

        // POST: api/Bug
        [HttpPost]
        public async Task<ActionResult<Bug>> Post(Bug bug)
        {
            _context.Bug.Add(bug);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBug", new { id = bug.Id }, bug);
        }

        // DELETE: api/Bug/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var bug = await _context.Bug.FindAsync(id);
            if (bug == null)
            {
                return NotFound();
            }

            _context.Bug.Remove(bug);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
