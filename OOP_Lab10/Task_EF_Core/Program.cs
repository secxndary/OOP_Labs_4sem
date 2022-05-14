using Courses_EF_Core;
using Courses_EF_Core.Entities;
using Microsoft.EntityFrameworkCore;

public class Program
{
    public static void Main()
    {
        try
        {
            var list = GetUsersAndRoles(true);
            foreach (var user in list)
            {
                Console.Write($"{user.UserName} {user.UserSurname}: ");
                foreach (var role in user.Roles)
                    Console.Write($"{role.RoleName} ");
                Console.WriteLine();
            }

            AddNewRole(430, "DevOps");

            AddRolesToActiveUsers("DevOps");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }


    public static List<Users> GetUsersAndRoles(bool flag)
    {
        using var context = new Context();
        return flag ?
            context.Users.Include(x => x.Roles).Where(x => x.IsActive == true).ToList() :
            context.Users.Include(x => x.Roles).ToList();
    }


    public static void AddNewRole(int id, string role)
    {
        if (string.IsNullOrEmpty(role))
            throw new ArgumentNullException("Role name is null!");
        using var context = new Context();

        if (context.Roles.Any(x => x.RoleName == role))
            throw new ArgumentException($"Role {role} already exists");
        if (context.Roles.Any(x => x.Id == id))
            throw new ArgumentException($"Id {id} already exists");

        context.Roles.Add(new Roles() { Id = id, RoleName = role });
        context.SaveChanges();
    }



    public static void AddRolesToActiveUsers(string roleName)
    {
        if (string.IsNullOrEmpty(roleName)) 
            throw new ArgumentException();
        using var context = new Context();

        if (!context.Roles.Any(x => x.RoleName == roleName)) 
            throw new ArgumentException($"Role {roleName} doesn't exist");
        var role = context.Roles.First(x => x.RoleName == roleName);

        using var transaction = context.Database.BeginTransaction();
        try
        {
            var userList = context.Users.Include(x => x.Roles).Where(x => x.IsActive == true).ToList();

            foreach (var user in userList)
            {
                if (user.Roles.Any(x => x.RoleName == roleName)) continue;

                context.UsersRoles.Add(new UsersRoles() { UserId = user.Id, RoleId = role.Id });
            }

            context.SaveChanges();

            transaction.Commit();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            transaction.Rollback();
        }
    }
}