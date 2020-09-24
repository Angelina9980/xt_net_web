using Domain;
using Epam.Nodes.Entities;
using Models;
using System;
using System.Collections.Generic;

namespace Mappers
{
    public static class AwardMapper
    {
        public static AwardEntity ToEntity(this Award award)
        {
            return new AwardEntity
            {
                Title = award.Title
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
                Title = model.Title
            };
        }
    }
}
