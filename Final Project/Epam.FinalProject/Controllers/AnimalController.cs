using BLL.Abstract;
using System.Collections.Generic;
using Entities;

namespace Controllers
{
    public class AnimalController
    {
        private readonly IAnimalLogic _animalLogic;
        public AnimalController(IAnimalLogic animalLogic)
        {
            _animalLogic = animalLogic;
        }
        public void AddAnimal(AnimalEntity animal)
        {
            _animalLogic.AddAnimal(animal);
        }
        public void DeleteAnimalById(int id)
        {
            _animalLogic.DeleteAnimalById(id);
        }

        public void EditAnimal(AnimalEntity animal)
        {
            _animalLogic.EditAnimal(animal);
        }

        public AnimalEntity GetAnimalById(int id)
        {
            return _animalLogic.GetAnimalById(id);
        }

        public List<AnimalEntity> GetAllAnimals()
        {
            return _animalLogic.GetAllAnimals();
        }

        public int GetDonation(int accountId, int animalId, int donation)
        {
            return _animalLogic.GetDonation(accountId, animalId, donation);
        }

        public Dictionary<int, int> GetAnimalDonations(int animalId)
        {
            return _animalLogic.GetAnimalDonations(animalId);
        }
    }
}
