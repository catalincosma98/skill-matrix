namespace SkillMatrix.Models
{
    public class Department
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public Department(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
