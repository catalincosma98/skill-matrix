using Microsoft.EntityFrameworkCore;
using SkillMatrix.Models;

namespace SkillMatrix.Database
{
    public class    ApplicationContext : DbContext
    {
        public DbSet<Language> Languages { get; set; } = null!;
        public DbSet<UserLanguage> UserLanguages { get; set; } = null!;
        public DbSet<SkillCategory> SkillCategories { get; set; } = null!;
        public DbSet<Skill> Skills { get; set; } = null!;
        public DbSet<UserSkill> UserSkills { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;


        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

    }
}
