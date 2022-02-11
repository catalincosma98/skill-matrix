using Microsoft.EntityFrameworkCore;

namespace SkillMatrix.Models
{
    public class    ApplicationContext : DbContext
    {
        public DbSet<Language> Languages { get; set; } = null!;
     
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }


    }
}
