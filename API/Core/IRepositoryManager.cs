using Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IRepositoryManager
    {
        ICertificateRepository Certificates { get; }
        IEducationRepository Educations { get; }
        IEmploymentRepository Employments { get; }
        IFeedbackRepository Feedbacks { get; }
        IKeyRepository Keys { get; }
        ILocationRepository Locations { get; }
        IPortfolioRepository Portfolios { get; }
        IProposalRepository Proposals { get; }
        IRoleRepository Roles { get; }
        ISkillRepository Skills { get; }
        IUserCertificateRepositiry UserCertificates { get; }
        IUserRepository Users { get; }
        IUserSkillRepository UserSkills { get; }
        IUserWorkRepository UserWorks { get; }
        IWorkKeyRepository WorkKeys { get; }
        IWorkRepository Works { get; }
    }
}
