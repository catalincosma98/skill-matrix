namespace SkillMatrix.Models
{
    public class UserLanguage
    {
        public long Id { get; set; }

        public Language language;

        public int Level;

        public UserLanguage(long id, Language language, int level)
        {
            Id = id;
            this.language = language;
            Level = level;
        }
    }
}
