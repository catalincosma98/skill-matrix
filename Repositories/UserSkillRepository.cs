using SkillMatrix.Database;
using SkillMatrix.Interfaces;
using SkillMatrix.Models;

namespace SkillMatrix.Repositories
{
    public class UserSkillRepository : GenericRepository<UserSkill>, IUserSkillRepository
    {
        public UserSkillRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
