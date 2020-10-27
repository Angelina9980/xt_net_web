using Entities;

namespace Mappers
{
    public static class AnimalMapper
    {
        public static AnimalEntity ToEntity(this AnimalEntity animal)
        {
            return new AnimalEntity
            {
                Name = animal.Name,
                Health = animal.Health,
                ImageData = animal.ImageData,
                ImageMineType = animal.ImageMineType
            };
        }
    }
}
