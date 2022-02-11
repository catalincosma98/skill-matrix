namespace SkillMatrix.Models
{
    public class User
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public string Position { get; set; }
        public Department? Department { get; set; }
        public List<Team>? Teams { get; set; }
        public List<UserLanguage> Languages { get; set; }
        public List<UserSkill> Skills { get; set; }
        public bool IsAdmin { get; set; }

        public User(long id, string firstName, string lastName, string email, string password, string profilePicture, string position, Department department, List<Team> teams, List<UserLanguage> languages, List<UserSkill> skills, bool isAdmin)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            ProfilePicture = profilePicture;
            Position = position;
            Department = department;
            Teams = teams;
            Languages = languages;
            Skills = skills;
            IsAdmin = isAdmin;
        }
    }
}
