#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Models;

namespace SkillMatrix.Controllers
{
    //  https://localhost:7179/api/languages/
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public LanguagesController(ApplicationContext context)
        {
            _context = context;
        }
        
        // Get all
        // GET: https://localhost:7179/api/languages/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Language>>> GetLanguages()
        {
            return await _context.Languages.ToListAsync();
        }

        // Get by Id
        // GET: https://localhost:7179/api/languages/getById/{id}
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Language>> GetLanguage(long id)
        {
            var language = await _context.Languages.FindAsync(id);

            if (language == null)
            {
                return NotFound();
            }

            return language;
        }

        // Insert
        // POST: https://localhost:7179/api/languages/insert
        [HttpPost("insert")]
        public async Task<ActionResult<Language>> PostLanguage(Language language)
        {
            _context.Languages.Add(language);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLanguage), new { id = language.Id }, language);
        }

        // Update
        // PUT: https://localhost:7179/api/languages/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutLanguage(long id, Language language)
        {
            if (id != language.Id)
            {
                return BadRequest();
            }

            _context.Entry(language).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageExists(id))
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

        // DELETE: https://localhost:7179/api/languages/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteLanguage(long id)
        {
            var language = await _context.Languages.FindAsync(id);
            if (language == null)
            {
                return NotFound();
            }

            _context.Languages.Remove(language);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LanguageExists(long id)
        {
            return _context.Languages.Any(e => e.Id == id);
        }
    }
}
