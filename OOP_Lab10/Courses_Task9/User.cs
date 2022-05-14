namespace Courses_Task9
{
    public class User
    {
        private string _id;
        private string _email;
        private string _name;
        private string _surname;
        private string _password;
        private List<string> _roles;

        public string Id { get => _id; private set => _id = value; }
        public string Email { get => _email; private set => _email = value; }
        public string Name { get => _name; private set => _name = value; }
        public string Surname { get => _surname; private set => _surname = value; }
        public string Password { get => _password; private set => _password = value; }
        public List<string> RolesList { get => _roles; private set => _roles = value; }

        public User(string id, string mail, string name, string surname, List<string> roles)
        {
            RolesList = new List<string>();
            Id = id;
            Email = mail;
            Name = name;
            Surname = surname;
            RolesList = roles;
        }

        public User(string id, string mail, string name, string surname)
        {
            Id = id;
            Email = mail;
            Name = name;
            Surname = surname;
            Password = "07dae6b6d30f254480bfc2efbc11010e";
        }

        public override string ToString()
        {
            var rolelist = "";
            foreach (var role in RolesList)
                rolelist += role.ToString() + " ";
            return $"{Name} {Surname} ( {rolelist}) — {Email}";
        }
    }
}
