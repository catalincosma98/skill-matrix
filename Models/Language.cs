namespace SkillMatrix.Models
{
    public class Language
    {
        public long Id { get; set; }
        public string? Name { get; set; }

        public Language()
        {
        }

        public Language(long id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}
