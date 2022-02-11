namespace SkillMatrix.Models
{
    public class Team
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<User> Members { get; set; }

        public Team(long id, string name, List<User> members)
        {
            Id = id;
            Name = name;
            Members = members;
        }
    }
}
