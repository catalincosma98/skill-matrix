using Microsoft.EntityFrameworkCore;

namespace SkillMatrix.Models
{
    public class LanguageContext : DbContext
    {
        public LanguageContext(DbContextOptions<LanguageContext> options) : base(options)
        {
        }

        public DbSet<Language> Languages { get; set; } = null!;
    }
}
