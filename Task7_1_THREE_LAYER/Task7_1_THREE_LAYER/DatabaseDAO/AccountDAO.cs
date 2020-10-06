using System.Collections.Generic;
using Epam.Nodes.Entities;
using System.Configuration;
using System.Data.SqlClient;
using DatabaseDAO.Abstract;


namespace DatabaseDAO
{
    public class AccountDAO : IAccountRepository
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public string[] GetRole(string username)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Role FROM dbo.Account WHERE Name = '" + username + "'";
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

                    var awardCheck = "SELECT * FROM Account WHERE Name = '" + account.Name + "' AND Password = '" + account.Password +"'";
                    var checkCommand = new SqlCommand(awardCheck, sqlConnection);

                    var query = "INSERT INTO dbo.Acccount(Name, Password, Role) Values(@Name, @Password, @Role)";
                    var command = new SqlCommand(query, sqlConnection);

                    command.Parameters.AddWithValue("@Name", account.Name);
                    command.Parameters.AddWithValue("@Password", account.Password);
                    command.Parameters.AddWithValue("@Role", account.Role);
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
