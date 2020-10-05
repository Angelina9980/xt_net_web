using Domain;
using Epam.Nodes.Entities;
using Models;

namespace Mappers
{
    public static class AwardMapper
    {
        public static AwardEntity ToEntity(this Award award)
        {
            return new AwardEntity
            {
                Title = award.Title,
                Id = award.Id
            };
        }

        public static Award ToDomain(this AwardModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new Award
            {
                Id = model.Id,
                Title = model.Title
            };
        }
    }
}
