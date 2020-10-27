using DataBaseDAO.Abstract;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace DataBaseDAO
{
    public class SubcriptionDAO : ISubsriptionDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void CancelSubcription(string userEmail)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Subcription WHERE Mail = '" + userEmail + "'";
                var command = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void GetSubcription(string userEmail)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Subcription(Mail) Values (@Mail)";
                var command = new SqlCommand(query, sqlConnection);

                command.Parameters.AddWithValue("@Mail", userEmail);

                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public bool SubcriptionCheck(string userEmail)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT * FROM Subcription WHERE Mail = '" + userEmail + "'";
                var command = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                if (command.ExecuteScalar() != null)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        public List<string> SubscriptionList()
        {
            List<string> subscriptionList = new List<string>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Mail FROM Subcription";

                var command = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.GetValue(0).ToString().Equals(""))
                    {
                        subscriptionList.Add(reader["Mail"] as string);
                    }
                }
            }
            return subscriptionList;
        }
    }
}
