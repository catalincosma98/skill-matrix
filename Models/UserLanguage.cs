namespace SkillMatrix.Models
{
    public class UserLanguage
    {
        public long Id { get; set; }
        public Language? Language { get; set; }
        public int? Level { get; set; }

        public UserLanguage()
        {
        }

        public UserLanguage(long id, Language? language, int? level)
        {
            Id = id;
            Language = language;
            Level = level;
        }
    }
}
