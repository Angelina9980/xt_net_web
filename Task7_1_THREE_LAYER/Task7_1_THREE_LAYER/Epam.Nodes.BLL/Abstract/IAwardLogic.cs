using Domain;
using Epam.Nodes.Entities;
using System;
using System.Collections.Generic;

namespace Epam.Nodes.BLL.Abstract
{
    public interface IAwardLogic
    {
        void AddAward(Award award);
        void DeleteAwardById(int id);
        List<AwardEntity> GetAllAwards();
    }
}
