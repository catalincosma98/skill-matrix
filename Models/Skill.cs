namespace SkillMatrix.Models
{
    public class Skill
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public SkillCategory skillCategory;

        public Skill(long id, string name, SkillCategory skillCategory)
        {
            Id = id;
            Name = name;
            this.skillCategory = skillCategory;
        }
    }
}
