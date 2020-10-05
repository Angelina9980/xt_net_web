using Domain;
using Epam.Nodes.BLL.Abstract;
using System;
using System.Collections.Generic;
using Mappers;
using Models;
using Epam.Nodes.Entities;
using System.Web.Mvc;

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

        public void EditAward(AwardModel model)
        {
            _awardLogic.EditAward(model.ToDomain());
        }


        public AwardEntity GetAwardById(int id)
        {
            return _awardLogic.GetAwardById(id);
        }
    }
}
