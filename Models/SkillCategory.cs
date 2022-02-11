namespace SkillMatrix.Models
{
    public class SkillCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public SkillCategory(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
