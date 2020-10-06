using System.Collections.Generic;
using Epam.Nodes.Entities;
using System.Configuration;
using System.Data.SqlClient;
using DatabaseDAO.Abstract;

namespace DatabaseDAO
{
    public class AwardDAO : IAwardRepository
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;

        public void AddAward(AwardEntity award)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO dbo.Award(Title) Values(@Title)";
                var command = new SqlCommand(query, sqlConnection);

                command.Parameters.AddWithValue("@Title", award.Title);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteAwardById(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var deleteQuery = "DELETE FROM dbo.UsersAndAwards WHERE ID_Award = " + id.ToString();
                var deleteCommand = new SqlCommand(deleteQuery, sqlConnection);

                var query = "DELETE FROM Award WHERE ID_Award = " + id.ToString();
                var command = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                deleteCommand.ExecuteNonQuery();
                command.ExecuteNonQuery();
            }
        }

        public void EditAward(AwardEntity award)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var currentAward = GetAwardById(award.Id);
                var query = "UPDATE Award SET Title = @newTitle WHERE ID_Award = " + award.Id.ToString();

                var command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@newTitle", award.Title);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<AwardEntity> GetAllAwards()
        {
            List<AwardEntity> awardEntities = new List<AwardEntity>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT ID_Award, Title FROM Award";
                var command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    awardEntities.Add(new AwardEntity { Id = (int)reader["ID_Award"], Title = reader["Title"] as string });
                }
            }
            return awardEntities;
        }

        public AwardEntity GetAwardById(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT Title FROM Award WHERE ID_Award = " + id.ToString();
                var command = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    return new AwardEntity
                    {
                        Id = id,
                        Title = reader["Title"] as string,
                    };
                }
                return null;
            }
        }


    }
}
