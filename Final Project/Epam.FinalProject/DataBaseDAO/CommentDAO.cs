using DataBaseDAO.Abstract;
using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Collections.Generic;
using Entities;

namespace DataBaseDAO
{
    public class CommentDAO : ICommentDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public void AddComment(string UserName, string Text, int animalId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "INSERT INTO Comment(UserMail, CommentText, ID_Animal) Values(@UserMail, @CommentText, @animalId)";
                var command = new SqlCommand(query, sqlConnection);

                command.Parameters.AddWithValue("@UserMail", UserName);
                command.Parameters.AddWithValue("@CommentText", Text);
                command.Parameters.AddWithValue("@animalId", animalId);

                sqlConnection.Open();

                command.ExecuteNonQuery();
            }
        }

        public void DeleteComment(int commentId)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "DELETE FROM Comment WHERE ID_Comment =" + commentId;
                var command = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();

                command.ExecuteNonQuery();
            }
        }

        public List<CommentEntity> GetAllCommentsById(int animalId)
        {
            List<CommentEntity> commentEntities = new List<CommentEntity>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT ID_Comment, UserMail, CommentText, ID_Animal FROM Comment WHERE ID_Animal = " + animalId;

                var command = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();

                var reader = command.ExecuteReader();


                while (reader.Read())
                {
                    if (!reader.GetValue(0).ToString().Equals(""))
                    {
                        commentEntities.Add(new CommentEntity
                        {
                            Id = (int)reader["ID_Comment"],
                            Text = reader["CommentText"] as string,
                            UserMail = reader["UserMail"] as string,
                            ID_animal = (int)reader["ID_Animal"],
                        });
                    }
                }
            }
            return commentEntities;
        }

    }
}
