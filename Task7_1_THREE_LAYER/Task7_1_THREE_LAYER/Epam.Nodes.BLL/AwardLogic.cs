using Domain;
using Epam.Nodes.BLL.Abstract;
//using Epam.Nodes.DAL.Abstract;
using DatabaseDAO.Abstract;
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

        public void EditAward(Award award)
        {
            _awardRepository.EditAward(award.ToEntity());
        }

        public List<AwardEntity> GetAllAwards()
        {
            return _awardRepository.GetAllAwards();
        }

        public AwardEntity GetAwardById(int id)
        {
            return _awardRepository.GetAwardById(id);
        }
    }
}
