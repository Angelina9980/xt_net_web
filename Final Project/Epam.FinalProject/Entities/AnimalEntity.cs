using Entities.Abstract;

namespace Entities
{
    public class AnimalEntity: BaseEntity
    {
        public string Name { get; set; }
        public int Donation { get; set; } 
        public string Text { get; set; }
        public string ImageUrl { get; set; }
    }
}
