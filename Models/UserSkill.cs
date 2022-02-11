namespace SkillMatrix.Models
{
    public class UserSkill
    {
        public long Id { get; set; }
        public Skill Skill { get; set; }
        public int Level { get; set; }

        public UserSkill(long id, Skill skill, int level)
        {
            Id = id;
            Skill = skill;
            Level = level;
        }
    }
}
