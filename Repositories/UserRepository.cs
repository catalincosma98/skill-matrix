using SkillMatrix.Database;
using SkillMatrix.Interfaces;
using SkillMatrix.Models;

namespace SkillMatrix.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {

        }
    }
}
