using System.Collections.Generic;
using Epam.Nodes.Entities;

namespace DatabaseDAO.Abstract
{
    public interface IAwardRepository
    {
        void AddAward(AwardEntity award);
        void DeleteAwardById(int id);
        List<AwardEntity> GetAllAwards();
        AwardEntity GetAwardById(int id);
        void EditAward(AwardEntity award);
    }
}
