#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Interfaces;
using SkillMatrix.Models;
using SkillMatrix.Repositories;

namespace SkillMatrix.Controllers
{
    //  https://localhost:7179/api/skills/
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillRepository SkillRepository;

        public SkillsController(SkillRepository skillRepository)
        {
            SkillRepository = skillRepository;
        }

        // Get all
        // GET: https://localhost:7179/api/skills/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Skill>>> GetSkills()
        {
            return await SkillRepository.FindAll();
        }

        // Get by Id
        // GET: https://localhost:7179/api/skills/getById/{id}
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<Skill>> GetSkill(long id)
        {
            var skill = await SkillRepository.FindById(id);

            if (skill == null)
            {
                return NotFound();
            }

            return skill;
        }

        // Insert
        // POST: https://localhost:7179/api/skills/insert
        [HttpPost("insert")]
        public async Task<ActionResult<Skill>> PostSkill(Skill skill)
        {
            await SkillRepository.Create(skill);
            return CreatedAtAction(nameof(GetSkill), new { id = skill.Id }, skill);
        }


        // Update
        // PUT: https://localhost:7179/api/skills/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutSkill(long id, Skill skill)
        {
            if (id != skill.Id)
            {
                return BadRequest();
            }

            try
            {
                await SkillRepository.Update(skill);
            }
            catch (DbUpdateConcurrencyException)
            {
                var skillEntry = await SkillRepository.FindById(id);
                if (skillEntry == null)
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

        // DELETE: https://localhost:7179/api/skills/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteSkill(long id)
        {
            var skill = await SkillRepository.FindById(id);
            if (skill == null)
            {
                return NotFound();
            }

            await SkillRepository.Delete(id);

            return NoContent();
        }
    }
}
