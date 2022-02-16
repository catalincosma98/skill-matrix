#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Models;
using SkillMatrix.Database;

namespace SkillMatrix.Controllers
{
    //  https://localhost:7179/api/skillcategories/
    [Route("api/[controller]")]
    [ApiController]
    public class SkillCategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public SkillCategoriesController(DataContext context)
        {
            _context = context;
        }

        // Get all
        // GET: https://localhost:7179/api/skillcategories/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<SkillCategory>>> GetSkillCategories()
        {
            return await _context.SkillCategories.ToListAsync();
        }

        // Get by Id
        // GET: https://localhost:7179/api/skillcategories/getById/{id}
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<SkillCategory>> GetSkillCategory(long id)
        {
            var skill = await _context.SkillCategories.FindAsync(id);

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }

        // Insert
        // POST: https://localhost:7179/api/skillcategories/insert
        [HttpPost("insert")]
        public async Task<ActionResult<SkillCategory>> PostSkillCategory(SkillCategory skillCategory)
        {
            _context.SkillCategories.Add(skillCategory);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSkillCategory), new { id = skillCategory.Id }, skillCategory);
        }

        // Update
        // PUT: https://localhost:7179/api/skillcategories/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutSkillCategory(long id, SkillCategory skillCategory)
        {
            if (id != skillCategory.Id)
            {
                return BadRequest();
            }

            _context.Entry(skillCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SkillCategoryExists(id))
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

        // DELETE: https://localhost:7179/api/skillcategories/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSkillCategory(long id)
        {
            var skillCategory = await _context.SkillCategories.FindAsync(id);
            if (skillCategory == null)
            {
                return NotFound();
            }

            _context.SkillCategories.Remove(skillCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SkillCategoryExists(long id)
        {
            return _context.SkillCategories.Any(e => e.Id == id);
        }
    }
}
