using Domain;
using Epam.Nodes.BLL.Abstract;
using Epam.Nodes.DAL.Abstract;
using System;
using System.Collections.Generic;
using Mappers;
using Epam.Nodes.Entities;

namespace Epam.Nodes.BLL
{
    public class AwardLogic : IAwardLogic
    {
        private readonly IAwardRepository _awardRepository;
        public AwardLogic(IAwardRepository awardRepository)
        {
            _awardRepository = awardRepository;
        }
        public void AddAward(Award award)
        {
            _awardRepository.AddAward(award.ToEntity());
        }

        public void DeleteAwardById(int id)
        {
            _awardRepository.DeleteAwardById(id);
        }

        public List<AwardEntity> GetAllAwards()
        {
            return _awardRepository.GetAllAwards();
        }
    }
}
