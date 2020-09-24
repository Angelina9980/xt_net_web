using Epam.Nodes.Entities;
using System;
using System.Collections.Generic;

namespace Epam.Nodes.DAL.Abstract
{
    public interface IAwardRepository
    {
        void AddAward(AwardEntity award);
        void DeleteAwardById(int id);
        List<AwardEntity> GetAllAwards();
    }
}
