using Domain;
using Epam.Nodes.BLL.Abstract;
using System;
using System.Collections.Generic;
using Mappers;
using Models;
using Epam.Nodes.Entities;

namespace Controllers
{
    public class AwardController
    {
        private readonly IAwardLogic _awardLogic;

        public AwardController(IAwardLogic awardLogic)
        {
            _awardLogic = awardLogic;
        }

        public void AddAward(AwardModel award)
        {
            _awardLogic.AddAward(award.ToDomain());
        }

        public void DeleteAwardById(int id)
        {
            _awardLogic.DeleteAwardById(id);
        }

        public List<AwardEntity> GetAllAwards()
        {
            return _awardLogic.GetAllAwards();
        }
    }
}
