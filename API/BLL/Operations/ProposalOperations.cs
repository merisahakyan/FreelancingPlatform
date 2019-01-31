using Core;
using Core.Database;
using Core.Models.BusinessModels;
using Core.Models.FilterModels;
using Core.Models.ViewModels;
using Core.OperationInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Operations
{
    public class ProposalOperations : IProposalOperations
    {
        IRepositoryManager _repositoryManager;
        public ProposalOperations(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<ProposalViewModel> GetProposalsForWork(int workId, ProposalFilterModel filter)
        {
            filter.WorkId = workId;

            var proposals = _repositoryManager.Proposals.GetAll();
            proposals = filter.Filter(proposals);

            return proposals.Select(p => new ProposalViewModel
            {
                Id = p.Id,
                Rate = p.Rate,
                User = new UserViewModel
                {
                    Id = p.User.Id,
                    Firstname = p.User.Firstname,
                    Lastname = p.User.Lastname,
                    Location = new LocationModel
                    {
                        Id = p.User.LocationId,
                        Country = p.User.Location.Country
                    }
                },
                WorkId = workId
            });
        }

        public void SubmitProposal(ProposalModel proposal)
        {
            var dbProposal = new Proposal
            {
                Date = DateTime.Now,
                DaysCount = proposal.DaysCount,
                Message = proposal.Message,
                Rate = proposal.Rate,
                UserId = proposal.UserId,
                WorkId = proposal.WorkId
            };

            _repositoryManager.Proposals.Add(dbProposal);
        }
    }
}
