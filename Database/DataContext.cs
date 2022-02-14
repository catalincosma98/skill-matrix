using Microsoft.EntityFrameworkCore;

namespace SkillMatrix.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
