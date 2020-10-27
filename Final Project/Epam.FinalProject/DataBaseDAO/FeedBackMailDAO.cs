using DataBaseDAO.Abstract;
using Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;

namespace DataBaseDAO
{
    public class FeedBackMailDAO : IFeedBackMailDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public void SendEmail(FeedBackMessage feedBackMessage)
        {
            if (feedBackMessage != null)
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var query = "INSERT INTO FeedBackMessage(UserMail, UserName, MessageSubject, Text) Values(@UserMail, @UserName, @MessageSubject, @Text)";
                    var command = new SqlCommand(query, sqlConnection);

                    command.Parameters.AddWithValue("@UserMail", feedBackMessage.UserMail);
                    command.Parameters.AddWithValue("@UserName", feedBackMessage.Name);
                    command.Parameters.AddWithValue("@MessageSubject", feedBackMessage.Subject);
                    command.Parameters.AddWithValue("@Text", feedBackMessage.MailText);

                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<FeedBackMessage> GetAllMessages()
        {
            List<FeedBackMessage> mailEntities = new List<FeedBackMessage>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT ID_FeedBackMessage, UserMail, UserName, MessageSubject, Text FROM FeedBackMessage";
                var command = new SqlCommand(query, sqlConnection);
                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    if (!reader.GetValue(0).ToString().Equals(""))
                    {
                        mailEntities.Add(new FeedBackMessage
                        {
                            Id = (int)reader["ID_FeedBackMessage"],
                            Name = reader["UserName"] as string,
                            UserMail = reader["UserMail"] as string,
                            Subject = reader["MessageSubject"] as string,
                            MailText = reader["Text"] as string,
                        });
                    }
                }
            }
            return mailEntities;
        }

    }
}
