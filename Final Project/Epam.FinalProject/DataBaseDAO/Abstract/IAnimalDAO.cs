using Entities;
using System.Collections.Generic;

namespace DataBaseDAO.Abstract
{
   public interface IAnimalDAO
    {
        void AddAnimal(AnimalEntity animal);
        void DeleteAnimalById(int id);
        List<AnimalEntity> GetAllAnimals();
        AnimalEntity GetAnimalById(int id);
        void EditAnimal(AnimalEntity animal);
        int GetDonation(int accountId, int animalId, int donation);
        Dictionary<int, int> GetAnimalDonations(int animalId);
    }
}
