using Core.Models.BusinessModels;
using Core.Models.FilterModels;
using Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.OperationInterfaces
{
    public interface IProposalOperations
    {
        void SubmitProposal(ProposalModel proposal);
        IEnumerable<ProposalViewModel> GetProposalsForWork(int workId, ProposalFilterModel filter);
        IEnumerable<ProposalViewModel> GetProposals(ProposalFilterModel filter);
    }
}
