using BLL;
using BLL.Abstract;
using DataBaseDAO;
using DataBaseDAO.Abstract;


namespace Resolver
{
    public  class AnimalResolver
    {
        private static readonly IAnimalLogic _animalLogic;
        private static readonly IAnimalDAO _animalDAO;
        public static IAnimalLogic AnimalLogic => _animalLogic;
        public static IAnimalDAO AnimalDAO => _animalDAO;
        static AnimalResolver()
        {
            _animalDAO= new AnimalDAO();
            _animalLogic = new AnimalLogic(_animalDAO);
        }
    }
}
