#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Models;
using SkillMatrix.Database;

namespace SkillMatrix.Controllers
{
    //  https://localhost:7179/api/userlanguages/
    [Route("api/[controller]")]
    [ApiController]
    public class UserLanguagesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public UserLanguagesController(ApplicationContext context)
        {
            _context = context;
        }

        // Get all
        // GET: https://localhost:7179/api/userlanguages/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserLanguage>>> GetUserLanguages()
        {
            return await _context.UserLanguages.ToListAsync();
        }

        // Get by Id
        // GET: https://localhost:7179/api/userlanguages/getById/{id}
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<UserLanguage>> GetUserLanguage(long id)
        {
            var userLanguage = await _context.UserLanguages.FindAsync(id);

            if (userLanguage == null)
            {
                return NotFound();
            }

            return userLanguage;
        }

        // Insert
        // POST: https://localhost:7179/api/userlanguages/insert
        [HttpPost("insert")]
        public async Task<ActionResult<UserLanguage>> PostUserLanguage(UserLanguage userLanguage)
        {
            _context.UserLanguages.Add(userLanguage);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserLanguage), new { id = userLanguage.Id }, userLanguage);
        }

        // Update
        // PUT: https://localhost:7179/api/userlanguages/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutUserLanguage(long id, UserLanguage userLanguage)
        {
            if (id != userLanguage.Id)
            {
                return BadRequest();
            }

            _context.Entry(userLanguage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserLanguageExists(id))
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

        // DELETE: https://localhost:7179/api/userlanguages/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUserLanguage(long id)
        {
            var userLanguage = await _context.UserLanguages.FindAsync(id);
            if (userLanguage == null)
            {
                return NotFound();
            }

            _context.UserLanguages.Remove(userLanguage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserLanguageExists(long id)
        {
            return _context.UserLanguages.Any(e => e.Id == id);
        }
    }
}
