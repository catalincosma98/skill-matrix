#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Models;
using SkillMatrix.Database;

namespace SkillMatrix.Controllers
{
    //  https://localhost:7179/api/userskills/
    [Route("api/[controller]")]
    [ApiController]
    public class UserSkillsController : ControllerBase
    {
        private readonly DataContext _context;

        public UserSkillsController(DataContext context)
        {
            _context = context;
        }

        // Get all
        // GET: https://localhost:7179/api/userskills/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserSkill>>> GetUserSkills()
        {
            return await _context.UserSkills.ToListAsync();
        }

        // Get by Id
        // GET: https://localhost:7179/api/userskills/getById/{id}
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<UserSkill>> GetUserSkill(long id)
        {
            var userSkill = await _context.UserSkills.FindAsync(id);

            if (userSkill == null)
            {
                return NotFound();
            }

            return userSkill;
        }

        // Insert
        // POST: https://localhost:7179/api/userskills/insert
        [HttpPost("insert")]
        public async Task<ActionResult<UserSkill>> PostUserSkill(UserSkill userSkill)
        {
            _context.UserSkills.Add(userSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserSkill), new { id = userSkill.Id }, userSkill);
        }

        // Update
        // PUT: https://localhost:7179/api/userskills/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutUserSkill(long id, UserSkill userSkill)
        {
            if (id != userSkill.Id)
            {
                return BadRequest();
            }

            _context.Entry(userSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserSkillExists(id))
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

        // DELETE: https://localhost:7179/api/userskills/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUserSkill(long id)
        {
            var userSkill = await _context.UserSkills.FindAsync(id);
            if (userSkill == null)
            {
                return NotFound();
            }

            _context.UserSkills.Remove(userSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserSkillExists(long id)
        {
            return _context.UserSkills.Any(e => e.Id == id);
        }
    }
}
