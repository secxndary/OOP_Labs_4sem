using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using Microsoft.Data.SqlClient;
using Courses_Task9;


public class Program
{
    public static void Main()
    {
        var user = new User(Guid.NewGuid().ToString(), "senchenya12@mail.ru", "Владислав", "Сенченя");
        //Sort();
        //Read();
        //Add(user);
        //Update();
        //Delete(user);
        SelectActiveUsers();
    }





    private static void Sort()
    {
        var connection = GetConnection();
        var cmd = new SqlCommand();

        Console.WriteLine("Enter column name to sort:");
        var column = Console.ReadLine();
        Console.WriteLine("Enter sort direction:");
        var sortDir = Console.ReadLine();


        switch (column)
        {
            case "Email":
                if (sortDir == "asc")
                    cmd = new SqlCommand("select u.Id, Email, UserName, UserSurname, RoleName, IsActive " +
                                 "from Users u join UsersRoles ur " +
                                 "on ur.UserId = u.Id " +
                                 "join Roles r " +
                                 "on r.Id = ur.RoleId " +
                                 "order by Email", connection);
                else
                    cmd = new SqlCommand("select u.Id, Email, UserName, UserSurname, RoleName, IsActive " +
                                 "from Users u join UsersRoles ur " +
                                 "on ur.UserId = u.Id " +
                                 "join Roles r " +
                                 "on r.Id = ur.RoleId " +
                                 "order by Email desc", connection);
                break;
            case "UserName":
                if (sortDir == "asc")
                    cmd = new SqlCommand("select u.Id, Email, UserName, UserSurname, RoleName, IsActive " +
                                 "from Users u join UsersRoles ur " +
                                 "on ur.UserId = u.Id " +
                                 "join Roles r " +
                                 "on r.Id = ur.RoleId " +
                                 "order by UserName", connection);
                else
                    cmd = new SqlCommand("select u.Id, Email, UserName, UserSurname, RoleName, IsActive " +
                                 "from Users u join UsersRoles ur " +
                                 "on ur.UserId = u.Id " +
                                 "join Roles r " +
                                 "on r.Id = ur.RoleId " +
                                 "order by UserName desc", connection);
                break;
            case "UserSurname":
                if (sortDir == "asc")
                    cmd = new SqlCommand("select u.Id, Email, UserName, UserSurname, RoleName, IsActive " +
                                 "from Users u join UsersRoles ur " +
                                 "on ur.UserId = u.Id " +
                                 "join Roles r " +
                                 "on r.Id = ur.RoleId " +
                                 "order by UserSurname", connection);
                else
                    cmd = new SqlCommand("select u.Id, Email, UserName, UserSurname, RoleName, IsActive " +
                                 "from Users u join UsersRoles ur " +
                                 "on ur.UserId = u.Id " +
                                 "join Roles r " +
                                 "on r.Id = ur.RoleId " +
                                 "order by UserSurname desc", connection);
                break;
            default:
                Console.WriteLine("Please, enter the correct column name.");
                break;
        }

        
        var listOfUsers = new List<User>();

        using (connection)
        {
            connection.Open();
            var reader = cmd.ExecuteReader();
            var data = new object[reader.FieldCount];
            var prevId = new Guid();


            while (reader.Read())
            {
                reader.GetValues(data);
                var mail = (string)data[1];
                var name = (string)data[2];
                var surname = (string)data[3];
                var role = (string)data[4];
                var rolesList = new List<string> { role };

                var id = (Guid)data[0];
                if (id == prevId)
                {
                    var prevUser = listOfUsers[listOfUsers.Count - 1];
                    prevUser.RolesList.Add(role);
                }

                else
                {
                    prevId = id;
                    listOfUsers.Add(new User(id.ToString().ToUpper(), mail, name, surname, rolesList));
                }
            }
            reader.Close();
        }

        foreach (var user in listOfUsers)
            Console.WriteLine(user);
    }



    private static void Update()
    {
        var connection = GetConnection();
        Console.WriteLine("Enter User email to update:");
        var email = Console.ReadLine();
        Console.WriteLine("Enter column to update:");
        var column = Console.ReadLine();
        Console.WriteLine("Enter new value:");
        var value = Console.ReadLine();

        var valueParam = new SqlParameter("@value", value);
        var EmailParam = new SqlParameter("@email", email);
        var cmd = new SqlCommand();
        var transaction = connection.BeginTransaction();
        cmd.Transaction = transaction;

        switch(column)
        {
            case "Email":
                cmd = new SqlCommand("update Users set Email = @value where Email = @email", connection);
                cmd.Parameters.Add(valueParam);
                cmd.Parameters.Add(EmailParam);
                break;
            case "UserName":
                cmd = new SqlCommand("update Users set UserName = @value where Email = @email", connection);
                cmd.Parameters.Add(valueParam);
                cmd.Parameters.Add(EmailParam);
                break;
            case "UserSurname":
                cmd = new SqlCommand("update Users set UserSurname = @value where Email = @email", connection);
                cmd.Parameters.Add(valueParam);
                cmd.Parameters.Add(EmailParam);
                break;
            default:
                Console.WriteLine("Please, enter the correct column name.");
                break;
        }

        using (connection)
        {
            connection.Open();
            try
            {
                var num = cmd.ExecuteNonQuery();
                Console.WriteLine($"Update: Affected {num} row(s)");
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("TRANSACTION ROLLBACK\n" + ex.Message);
                transaction.Rollback();
            }

        }
    }




    private static void Delete(User user)
    {
        var connection = GetConnection();

        var paramEmail = new SqlParameter("@email", user.Email);
        var cmd = new SqlCommand("delete from Users where Email = @email", connection);
        cmd.Parameters.Add(paramEmail);


        using (connection)
        {
            connection.Open();
            var transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                var num = cmd.ExecuteNonQuery();
                Console.WriteLine($"Delete: Affected {num} row(s)");
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("TRANSACTION ROOLBACK\n" + ex.Message);
                transaction.Rollback();
            }
        }
    }




    private static void Read()
    {
        var connection = GetConnection();
        var cmd = new SqlCommand("select u.Id, Email, UserName, UserSurname, RoleName, IsActive " +
                                 "from Users u join UsersRoles ur " +
                                 "on ur.UserId = u.Id " +
                                 "join Roles r " +
                                 "on r.Id = ur.RoleId " +
                                 "order by u.Id", connection);

        var listOfUsers = new List<User>();


        using (connection)
        {
            connection.Open();
            var reader = cmd.ExecuteReader();
            var data = new object[reader.FieldCount];
            var prevId = new Guid();


            while (reader.Read())
            {
                reader.GetValues(data);
                var mail = (string)data[1];
                var name = (string)data[2];
                var surname = (string)data[3];
                var role = (string)data[4];
                var rolesList = new List<string> { role };

                var id = (Guid)data[0];
                if (id == prevId)
                {
                    var prevUser = listOfUsers[listOfUsers.Count - 1];
                    prevUser.RolesList.Add(role);
                }

                else
                {
                    prevId = id;
                    listOfUsers.Add(new User(id.ToString().ToUpper(), mail, name, surname, rolesList));
                }
            }
            reader.Close();
        }

        foreach (var user in listOfUsers)
            Console.WriteLine(user);
    }





    private static void Add(User user)
    {
        var connection = GetConnection();

        var paramID = new SqlParameter("@id", user.Id);
        var paramName = new SqlParameter("@name", user.Name);
        var paramSurName = new SqlParameter("@surname", user.Surname);
        var paramEmail = new SqlParameter("@email", user.Email);
        var paramActive = new SqlParameter("@active", false);
        var paramPassword = new SqlParameter("@password", user.Password);
        var cmd = new SqlCommand("insert into Users (Id, Email, PasswordHash, UserName, UserSurname, IsActive) " +
            "values (@id, @email, @password, @name, @surname, @active)", connection);
        cmd.Parameters.Add(paramID);
        cmd.Parameters.Add(paramName);
        cmd.Parameters.Add(paramSurName);
        cmd.Parameters.Add(paramEmail);
        cmd.Parameters.Add(paramActive);
        cmd.Parameters.Add(paramPassword);





        using (connection)
        {
            connection.Open();
            var transaction = connection.BeginTransaction();
            cmd.Transaction = transaction;

            try
            {
                var num = cmd.ExecuteNonQuery();
                transaction.Commit();
                Console.WriteLine($"Create: Affected {num} row(s)");
            }
            catch (Exception ex)
            {
                Console.WriteLine("TRANSACTION ROLLBACK\n" + ex.Message);
                transaction.Rollback();
            }

        }
    }




    private static void SelectActiveUsers()
    {
        var connection = GetConnection();

        var cmd = new SqlCommand("select u.Id, Email, UserName, UserSurname, RoleName " +
                                 "from Users u join UsersRoles ur " +
                                 "on ur.UserId = u.Id " +
                                 "join Roles r " +
                                 "on r.Id = ur.RoleId " +
                                 "where IsActive = 1 " +
                                 "order by u.Id", connection);

        var listOfUsers = new List<User>();


        using (connection)
        {
            connection.Open();
            var reader = cmd.ExecuteReader();
            var data = new object[reader.FieldCount];
            var prevId = new Guid();


            while (reader.Read())
            {
                reader.GetValues(data);
                var mail = (string)data[1];
                var name = (string)data[2];
                var surname = (string)data[3];
                var role = (string)data[4];
                var rolesList = new List<string> { role };

                var id = (Guid)data[0];
                if (id == prevId)
                {
                    var prevUser = listOfUsers[listOfUsers.Count - 1];
                    prevUser.RolesList.Add(role);
                }

                else
                {
                    prevId = id;
                    listOfUsers.Add(new User(id.ToString().ToUpper(), mail, name, surname, rolesList));
                }
            }
            reader.Close();
        }

        SaveJson(listOfUsers);
    }


    private static SqlConnection GetConnection()
    {
        using var sr = new StreamReader("../../../config.txt");

        var builder = new SqlConnectionStringBuilder
        {
            DataSource = sr.ReadLine(),
            InitialCatalog = sr.ReadLine(),
            IntegratedSecurity = Convert.ToBoolean(sr.ReadLine()),
            Pooling = Convert.ToBoolean(sr.ReadLine())
        };

        return new SqlConnection(builder.ToString());
    }



    private static void SaveJson(object obj)
    {
        var options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
            WriteIndented = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        var json = JsonSerializer.Serialize(obj, options);
        File.WriteAllText(Path.GetFullPath(@"../../../out.json"), json);
    }

}