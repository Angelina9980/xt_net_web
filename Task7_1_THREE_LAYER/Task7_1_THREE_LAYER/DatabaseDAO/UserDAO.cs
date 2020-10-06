using System.Collections.Generic;
using Epam.Nodes.Entities;
using System.Configuration;
using System.Data.SqlClient;
using DatabaseDAO.Abstract;
using System;
using System.Linq;

namespace DatabaseDAO
{
    public class UserDAO : IUserRepository
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public void AddUser(UserEntity user)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Users(Name, DateOfBirth, Age) Values(@Name, @Date, @Age)";
                var command = new SqlCommand(query, sqlConnection);
                var userIdentity = "SELECT @@IDENTITY";
                var identityCommand = new SqlCommand(userIdentity, sqlConnection);
                
                command.Parameters.AddWithValue("@Name", user.Name);
                command.Parameters.AddWithValue("@Date", user.DateOfBirth);
                command.Parameters.AddWithValue("@Age", user.Age);

                sqlConnection.Open();
                command.ExecuteNonQuery();
                var userId = identityCommand.ExecuteNonQuery();

                if (user.ListOfAwards.Count != 0)
                {
                    foreach (var award in user.ListOfAwards)
                    {
                        var awardCheck = "SELECT * FROM Award WHERE ID_Award =" + award;
                        var checkCommand = new SqlCommand(awardCheck, sqlConnection);

                       if (checkCommand.ExecuteScalar() != null) {
                            var secondQuery = "INSERT INTO dbo.UsersAndAwards(ID_Award, ID_Users) Values(@Award_id, @User_id)";
                            var secondCommand = new SqlCommand(secondQuery, sqlConnection);
                            secondCommand.Parameters.AddWithValue("@Award_id", award);
                            secondCommand.Parameters.AddWithValue("@User_id", userId);
                            secondCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        public void DeleteUserById(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var deleteQuery = "DELETE FROM dbo.UsersAndAwards WHERE ID_USERS = " + id.ToString();
                var deleteCommand = new SqlCommand(deleteQuery, sqlConnection);

                sqlConnection.Open();
                deleteCommand.ExecuteNonQuery();

                var query = "DELETE FROM dbo.Users WHERE ID_Users = " + id.ToString();
                var command = new SqlCommand(query, sqlConnection);

                command.ExecuteNonQuery();
            }
        }

        public void EditUser(UserEntity user)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var currentUser = GetUserById(user.Id);
                var query = "UPDATE dbo.Users SET Name = @newName, DateOfBirth = @newDate, Age = @newAge WHERE ID_Users = " + user.Id.ToString();

                var command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@newName", user.Name);
                command.Parameters.AddWithValue("@newDate", user.DateOfBirth);
                command.Parameters.AddWithValue("@newAge", user.Age);

                sqlConnection.Open();
                command.ExecuteNonQuery();

                if (!user.ListOfAwards.Equals(currentUser.ListOfAwards))
                {

                    var deleteQuery = "DELETE FROM dbo.UsersAndAwards WHERE ID_Users =" + user.Id.ToString();
                    var deleteCommand = new SqlCommand(deleteQuery, sqlConnection);
                    deleteCommand.ExecuteNonQuery();
                    var secondQuery = "INSERT INTO dbo.UsersAndAwards(@ID_Award, @ID_Users) Values(@Award_Id, @User_id)";

                    var secondCommand = new SqlCommand(secondQuery, sqlConnection);
                    secondCommand.Parameters.AddWithValue("@User_id", user.Id);

                    foreach (var award in user.ListOfAwards)
                    {
                        secondCommand.Parameters.AddWithValue("@Award_id", award);
                        secondCommand.ExecuteNonQuery();
                    }
                }
            }
        }

        public List<UserEntity> GetAllUsers()
        {
            List<UserEntity> userEntities = new List<UserEntity>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                
                var query = "SELECT Age, DateOfBirth, Name, ID_Users FROM dbo.Users";
                var command = new SqlCommand(query, sqlConnection);
                List<int> awards = new List<int>();

                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    try
                    {
                        var awardQuery = "SELECT ID_Award FROM dbo.UsersAndAwards WHERE ID_Users=" + (int)reader["ID_Users"];
                        var awardCommand = new SqlCommand(awardQuery, sqlConnection);
                        var awardReader = awardCommand.ExecuteReader();
                        while (awardReader.Read())
                        {
                            if (!awards.Contains((int)awardReader["ID_Award"])) {
                                awards.Add((int)awardReader["ID_Award"]);
                            }
                        }
                    }
                    catch(SqlException exeption)
                    {
                        Console.WriteLine(exeption.Message);
                    }

                    userEntities.Add(new UserEntity
                    {
                        Id = (int)reader["ID_Users"],
                        Name = reader["Name"] as string,
                        Age = (int)reader["Age"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        ListOfAwards = awards,
                    });
                }
            }

            return userEntities;
        }

        public UserEntity GetUserById(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Name, DateOfBirth, Age FROM dbo.Users WHERE ID_Users= " + id.ToString();
                var command = new SqlCommand(query, sqlConnection);
                var awardQuery = "SELECT ID_Award FROM dbo.UsersAndAwards WHERE ID_Users=" + id.ToString();
                var awardCommand = new SqlCommand(awardQuery, sqlConnection);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                var awardReader = awardCommand.ExecuteReader();

                List<int> awards = new List<int>();

                while (awardReader.Read())
                {
                    awards.Add((int)awardReader["ID_Award"]);
                }

                while (reader.Read())
                {
                    return new UserEntity
                    {
                        Id = id,
                        Name = reader["Name"] as string,
                        Age = (int)reader["Age"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        ListOfAwards = awards,
                    };
                }

                return null;
            }
        }
    }
}
