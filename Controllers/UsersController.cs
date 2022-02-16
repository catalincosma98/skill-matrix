#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkillMatrix.Interfaces;
using SkillMatrix.Models;
using SkillMatrix.Repositories;

namespace SkillMatrix.Controllers
{
    //  https://localhost:7179/api/users/
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository UserRepository;

        public UsersController(UserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        // Get all
        // GET: https://localhost:7179/api/users/eagerall
        [HttpGet("eagerall")]
        public async Task<ActionResult<IEnumerable<User>>> EagerGetUsers()
        {
            string[] children = { "Department", "Teams", "Languages", "Skills" };
            return await UserRepository.EagerFindAll(children);
        }

        // Get all
        // GET: https://localhost:7179/api/users/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await UserRepository.FindAll();
        }

        // Get by Id
        // GET: https://localhost:7179/api/users/getById/{id}
        [HttpGet("getById/{id}")]
        public async Task<ActionResult<User>> GetUser(long id)
        {
            var user = await UserRepository.FindById(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // Insert
        // POST: https://localhost:7179/api/users/insert
        [HttpPost("insert")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            await UserRepository.Create(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }


        // Update
        // PUT: https://localhost:7179/api/users/update/{id}
        [HttpPut("update/{id}")]
        public async Task<IActionResult> PutUser(long id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                await UserRepository.Update(user);
            }
            catch (DbUpdateConcurrencyException)
            {
                var userEntry = await UserRepository.FindById(id);
                if (userEntry == null)
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

        // DELETE: https://localhost:7179/api/users/delete/{id}
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteUser(long id)
        {
            var user = await UserRepository.FindById(id);
            if (user == null)
            {
                return NotFound();
            }

            await UserRepository.Delete(id);

            return NoContent();
        }
    }
}
