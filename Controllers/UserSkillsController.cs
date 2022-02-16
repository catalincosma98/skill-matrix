#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Models;
using SkillMatrix.Interfaces;
using SkillMatrix.Repositories;

namespace SkillMatrix.Controllers
{
    //  https://localhost:7179/api/userskills/
    [Route("api/[controller]")]
    [ApiController]
    public class UserSkillsController : ControllerBase
    {
        private readonly IUserSkillRepository UserSkillRepository;

        public UserSkillsController(UserSkillRepository userSkillRepository)
        {
            UserSkillRepository = userSkillRepository;
        }

        // Get all
        // GET: https://localhost:7179/api/userskills/eagerall
        [HttpGet("eagerall")]
        public async Task<ActionResult<IEnumerable<UserSkill>>> EagerGetUserSkills()
        {
            string[] children = {"Skill"};
            return await UserSkillRepository.EagerFindAll(children);
        }

        // Get all
        // GET: https://localhost:7179/api/userskills/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<UserSkill>>> GetUserSkills()
        {
            return await UserSkillRepository.FindAll();
        }

        // Get by Id
        // GET: https://localhost:7179/api/userskills/getById/{id}
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<UserSkill>> GetUserSkill(long id)
        {
            var userSkill = await UserSkillRepository.FindById(id);

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
            await UserSkillRepository.Create(userSkill);
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

            try
            {
                await UserSkillRepository.Update(userSkill);
            }
            catch (DbUpdateConcurrencyException)
            {
                var userSkillEntry = await UserSkillRepository.FindById(id);
                if (userSkillEntry == null)
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
            var userSkill = await UserSkillRepository.FindById(id);
            if (userSkill == null)
            {
                return NotFound();
            }

            await UserSkillRepository.Delete(id);

            return NoContent();
        }
    }
}
