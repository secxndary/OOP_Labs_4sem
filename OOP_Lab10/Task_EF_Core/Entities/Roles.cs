
namespace Courses_EF_Core.Entities
{
    public class Roles
    {
        public int Id { get; set; }
        public string RoleName { get; set; }

        public ICollection<Users> Users { get; set; }

        public Roles() => Users = new HashSet<Users>();
    }
}
