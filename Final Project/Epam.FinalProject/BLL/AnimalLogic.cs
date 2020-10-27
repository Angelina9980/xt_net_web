using BLL.Abstract;
using DataBaseDAO.Abstract;
using Entities;
using System.Collections.Generic;

namespace BLL
{
    public class AnimalLogic : IAnimalLogic
    {
        private readonly IAnimalDAO _animalDAO;

        public AnimalLogic(IAnimalDAO animalDAO)
        {
            _animalDAO = animalDAO;
        }
        public void AddAnimal(AnimalEntity animal)
        {
            _animalDAO.AddAnimal(animal);
        }

        public void DeleteAnimalById(int id)
        {
            _animalDAO.DeleteAnimalById(id);
        }

        public void EditAnimal(AnimalEntity animal)
        {
            _animalDAO.EditAnimal(animal);
        }

        public List<AnimalEntity> GetAllAnimals()
        {
            return _animalDAO.GetAllAnimals();
        }

        public AnimalEntity GetAnimalById(int id)
        {
            return _animalDAO.GetAnimalById(id);
        }

        public Dictionary<int, int> GetAnimalDonations(int animalId)
        {
            return _animalDAO.GetAnimalDonations(animalId);
        }

        public int GetDonation(int accountId, int animalId, int donation)
        {
            return _animalDAO.GetDonation(accountId, animalId, donation);
        }
    }
}
