using Microsoft.EntityFrameworkCore;
using SkillMatrix.Models;

namespace SkillMatrix.Database
{
    public class    ApplicationContext : DbContext
    {
        public DbSet<Language> Languages { get; set; } = null!;
        public DbSet<Skill> Skills { get; set; } = null!;

        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

    }
}
