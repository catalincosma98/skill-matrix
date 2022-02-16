using SkillMatrix.Database;
using SkillMatrix.Interfaces;
using SkillMatrix.Models;

namespace SkillMatrix.Repositories
{
    public class SkillRepository : GenericRepository<Skill>, ISkillRepository
    {
        public SkillRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
