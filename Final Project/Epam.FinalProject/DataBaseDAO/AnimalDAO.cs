using DataBaseDAO.Abstract;
using Entities;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;

namespace DataBaseDAO
{
    public class AnimalDAO : IAnimalDAO
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        public void AddAnimal(AnimalEntity animal)
        {
            if (animal != null)
            {
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var awardCheck = "SELECT * FROM Animal WHERE Name ='" + animal.Name + "'";
                    var checkCommand = new SqlCommand(awardCheck, sqlConnection);

                    var query = "INSERT INTO Animal(Name, AnimalInfo, ImageUrl) Values(@Name, @AnimalInfo, @ImageUrl)";
                    var command = new SqlCommand(query, sqlConnection);

                    command.Parameters.AddWithValue("@Name", animal.Name);
                    command.Parameters.AddWithValue("@AnimalInfo", animal.Text);
                    command.Parameters.AddWithValue("@ImageUrl", animal.ImageUrl);
                    sqlConnection.Open();

                    if (checkCommand.ExecuteScalar() == null)
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteAnimalById(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var firstQuery = "DELETE FROM Animal WHERE ID_Animal =" + id;
                var firstCommand = new SqlCommand(firstQuery, sqlConnection);

                var secondQuery = "DELETE FROM Donations WHERE ID_Animal =" + id;
                var secondCommand = new SqlCommand(secondQuery, sqlConnection);

                var thirdQuery = "DELETE FROM Comment WHERE ID_Animal =" + id;
                var thirdCommand = new SqlCommand(thirdQuery, sqlConnection);

                sqlConnection.Open();

                
                secondCommand.ExecuteNonQuery();
                thirdCommand.ExecuteNonQuery();
                firstCommand.ExecuteNonQuery();
            }
        }

        public void EditAnimal(AnimalEntity animal)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "UPDATE Animal SET Name = @Name, AnimalInfo = @AnimalInfo, ImageUrl = @ImageUrl WHERE ID_Animal =" + animal.Id;

                var command = new SqlCommand(query, sqlConnection);
                command.Parameters.AddWithValue("@Name", animal.Name);
                command.Parameters.AddWithValue("@AnimalInfo", animal.Text);
                command.Parameters.AddWithValue("@ImageUrl", animal.ImageUrl);
                sqlConnection.Open();
                command.ExecuteNonQuery();
            }
        }

        public List<AnimalEntity> GetAllAnimals()
        {
            List<AnimalEntity> animalEntities = new List<AnimalEntity>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT ID_Animal, Name, AnimalInfo, ImageUrl FROM Animal";

                var command = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    animalEntities.Add(new AnimalEntity
                    {
                        Id = (int)reader["ID_Animal"],
                        Name = reader["Name"] as string,
                        Text = reader["AnimalInfo"] as string,
                        ImageUrl = reader["imageUrl"] as string,
                    });
                    var animalId = animalEntities.Last().Id;
                    var donationQuery = "SELECT SUM(Donation) FROM Donations WHERE ID_Animal = " + animalId;
                    var donationCommand = new SqlCommand(donationQuery, sqlConnection);

                    var donation = 0;

                    var sumReader = donationCommand.ExecuteReader();
                    sumReader.Read();
                    if (!sumReader.GetValue(0).ToString().Equals(""))
                    {
                        donation = (int)sumReader.GetValue(0);
                    }

                    animalEntities.Last().Donation = donation;
                }
            }
            return animalEntities;
        }

        public AnimalEntity GetAnimalById(int id)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT ID_Animal, Name, AnimalInfo, ImageUrl FROM Animal WHERE ID_Animal =" + id;
                var donationQuery = "SELECT SUM(Donation) FROM Donations WHERE ID_Animal = " + id;
                var command = new SqlCommand(query, sqlConnection);
                var donationCommand = new SqlCommand(donationQuery, sqlConnection);

                var donation = 0;

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                var sumReader = donationCommand.ExecuteReader();
                sumReader.Read();

                while (reader.Read())
                {
                    if (!sumReader.GetValue(0).ToString().Equals(""))
                    {
                        donation = (int)sumReader.GetValue(0);
                    }
                    return new AnimalEntity
                    {
                        Id = (int)reader["ID_Animal"],
                        Name = reader["Name"] as string,
                        Text = reader["AnimalInfo"] as string,
                        ImageUrl = reader["ImageUrl"] as string,
                        Donation = donation,
                    };
                }
                return null;
            }
        }

        public Dictionary<int, int> GetAnimalDonations(int animalId)
        {
            Dictionary<int, int> animalDonations = new Dictionary<int, int>();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                var query = "SELECT ID_Account, Donation FROM Donations WHERE ID_Animal =" + animalId;

                var command = new SqlCommand(query, sqlConnection);

                sqlConnection.Open();
                var reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    if (!reader.GetValue(0).ToString().Equals(""))
                    {
                        animalDonations.Add((int)reader["ID_Account"], (int)reader["Donation"]);
                    }
                }
            }
            return animalDonations;
        }

        public int GetDonation(int accountId, int animalId, int donation)
        {
            int animalDonation = GetAnimalById(animalId).Donation;
            if (donation > 0)
            {
                animalDonation += donation;
                using (var sqlConnection = new SqlConnection(_connectionString))
                {
                    var query = "INSERT INTO Donations(ID_Account, ID_Animal, Donation) VALUES(@ID_Account, @ID_Animal, @Donation)";
                    var command = new SqlCommand(query, sqlConnection);

                    command.Parameters.AddWithValue("@ID_Account", accountId);
                    command.Parameters.AddWithValue("@ID_Animal", animalId);
                    command.Parameters.AddWithValue("@Donation", donation);

                    sqlConnection.Open();
                    command.ExecuteNonQuery();
                }
            }
            return animalDonation;
        }
    }
}
