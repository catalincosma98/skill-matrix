namespace SkillMatrix.Models
{
    public class Department
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public List<Team>? Teams { get; set; }

        public Department()
        {
        }

        public Department(long id, string? name, List<Team>? teams)
        {
            Id = id;
            Name = name;
            Teams = teams;
        }
    }
}
