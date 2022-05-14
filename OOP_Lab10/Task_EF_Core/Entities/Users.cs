
namespace Courses_EF_Core.Entities
{
    public class Users
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public bool IsActive { get; set; }

        public ICollection<Roles> Roles { get; set; }

        public Users() => Roles = new HashSet<Roles>();
    }
}
