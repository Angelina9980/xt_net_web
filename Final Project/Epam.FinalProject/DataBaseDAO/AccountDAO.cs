using DataBaseDAO.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace DataBaseDAO
{
    public class AccountDAO : IAccountDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void DeleteAccountById(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var firstQuery = "DELETE FROM Account WHERE ID_Account =" + id;
                var firstCommand = new SqlCommand(firstQuery, sqlConnection);

                var secondQuery = "DELETE FROM Donations WHERE ID_Account =" + id;
                var secondCommand = new SqlCommand(secondQuery, sqlConnection);

                var userMail = GetAccountById(id).Email;

                var thirdQuery = "DELETE FROM Comment WHERE UserMail ='" + userMail + "'";
                var thirdCommand = new SqlCommand(thirdQuery, sqlConnection);

                var fourthQuery = "DELETE FROM Subcription WHERE Mail ='" + userMail + "'";
                var fourthCommand = new SqlCommand(fourthQuery, sqlConnection);

                var fifthQuery = "DELETE FROM FeedBackMessage WHERE UserMail ='" + userMail + "'";
                var fifthCommand = new SqlCommand(fifthQuery, sqlConnection);


                sqlConnection.Open();

                secondCommand.ExecuteNonQuery();
                thirdCommand.ExecuteNonQuery();
                fourthCommand.ExecuteNonQuery();
                fifthCommand.ExecuteNonQuery();
                firstCommand.ExecuteNonQuery();
            }
        }

        public void EditAccount(AccountEntity account)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                DateTime dateTimeNow = DateTime.Today;
                int age = dateTimeNow.Year - account.DateOfBirth.Year;
                if (account.DateOfBirth > dateTimeNow.AddYears(-age))
                {
                    age--;
                }

                var query = "UPDATE Account SET Name = @newName, DateOfBirth = @newDate, Age = @newAge, Password = @newPassword," +
                " Mail = @newMail, Number = @newNumber, CardInformation = @newCard, Role = @newRole, Balance = @newBalance WHERE Mail= '" + account.Email +"'";

                var command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@newName", account.Name);
                command.Parameters.AddWithValue("@newDate", account.DateOfBirth);
                command.Parameters.AddWithValue("@newAge", age);
                command.Parameters.AddWithValue("@newPassword", account.Password);
                command.Parameters.AddWithValue("@newMail", account.Email);
                command.Parameters.AddWithValue("@newNumber", account.Number);
                command.Parameters.AddWithValue("@newCard", account.CardInformation);
                command.Parameters.AddWithValue("@newRole", account.Role);
                command.Parameters.AddWithValue("@newBalance", account.Balance);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void EditBalance(string email, int cost, bool Operation)
        {
            int userBalance = GetAccountByEmail(email).Balance;

            if (Operation)
            {
                if (userBalance > cost)
                {
                    userBalance -= cost;
                }
            }
            else
            {
                userBalance += cost;
            }

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Account SET Balance = @newBalance WHERE Mail = '" + email + "'";
                var command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@newBalance", userBalance);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public AccountEntity GetAccountByEmail(string email)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT ID_Account, Name, Password, Mail, Balance, Number, CardInformation, DateOfBirth, Role, Age FROM Account WHERE Mail = '" + email + "'";
                var command = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new AccountEntity
                    {
                        Id = (int)reader["ID_Account"],
                        Name = reader["Name"] as string,
                        Age = (int)reader["Age"],
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Password = reader["Password"] as string,
                        Email = reader["Mail"] as string,
                        Balance = (int)reader["Balance"],
                        CardInformation = reader["CardInformation"] as string,
                        Number = reader["Number"] as string,
                        Role = reader["Role"] as string,
                    };
                }
                return null;
            }
        }

        public AccountEntity GetAccountById(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Account WHERE ID_Account =" + id;
                var command = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new AccountEntity
                    {
                        Id = (int)reader["ID_Account"],
                        Name = reader["Name"] as string,
                        Role = reader["Role"] as string,
                        Password = reader["Password"] as string,
                        Email = reader["Mail"] as string,
                        Balance = (int)reader["Balance"],
                        Number = reader["Number"] as string,
                        CardInformation = reader["CardInformation"] as string,
                        DateOfBirth = (DateTime)reader["DateOfBirth"],
                        Age = (int)reader["age"],
                    };
                }
                return null;
            }
        }

        public List<AccountEntity> GetAllAccounts()
        {
            List<AccountEntity> accountEntities = new List<AccountEntity>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT ID_Account, Name, Password, Mail, Balance, Number, CardInformation, DateOfBirth, Role, Age FROM Account";
                var command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    accountEntities.Add(new AccountEntity { Id = (int)reader["ID_Account"], Name = reader["Name"] as string,
                        Password = reader["Password"] as string, Email = reader["Mail"] as string, Balance = (int)reader["Balance"], Number = reader["Number"] as string,
                        CardInformation = reader["CardInformation"] as string, Role = reader["Role"] as string, DateOfBirth = (DateTime)reader["DateOfBirth"], Age = (int)reader["Age"],
                    });
                }
            }
            return accountEntities;
        }

        public string[] GetRole(string username)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Role FROM dbo.Account WHERE Mail = '" + username + "'";
                var command = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new[] { reader["Role"] as string};
                }
            }
            return null;
        }

        public void Registration(AccountEntity account)
        {
            if (account != null)
            {
                if (account.Role != "admin")
                {
                    account.Role = "user";
                }

                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var awardCheck = "SELECT * FROM Account WHERE Mail = '" + account.Email + "'";
                    var checkCommand = new SqlCommand(awardCheck, sqlConnection);

                    var query = "INSERT INTO Account(Name, Mail, Password, Role, Balance, CardInformation, Number, DateOfBirth, Age) Values(@Name, @Email, @Password, @Role, @Balance, @CardInformation, @Number, @DateOfBirth, @Age)";
                    var command = new SqlCommand(query, sqlConnection);

                    DateTime dateTimeNow = DateTime.Today;
                    int age = dateTimeNow.Year - account.DateOfBirth.Year;
                    if (account.DateOfBirth > dateTimeNow.AddYears(-age))
                    {
                        age--;
                    }

                    command.Parameters.AddWithValue("@Name", account.Name);
                    command.Parameters.AddWithValue("@Password", account.Password);
                    command.Parameters.AddWithValue("@Email", account.Email);
                    command.Parameters.AddWithValue("@Role", account.Role);
                    command.Parameters.AddWithValue("@Balance", 0);
                    command.Parameters.AddWithValue("@CardInformation", " ");
                    command.Parameters.AddWithValue("@Number", account.Number);
                    command.Parameters.AddWithValue("@DateOfBirth", account.DateOfBirth.Date);
                    command.Parameters.AddWithValue("@Age", age);
                    sqlConnection.Open();

                    if (checkCommand.ExecuteScalar() == null)
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }


    }
}
