namespace SkillMatrix.Models
{
    public class SkillCategory
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }

        public SkillCategory(long id, string name, List<Skill> skills)
        {
            Id = id;
            Name = name;
            Skills = skills;
        }
    }
}
