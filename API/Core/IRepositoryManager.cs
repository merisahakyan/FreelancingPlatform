using Core.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core
{
    public interface IRepositoryManager
    {
        ICertificateRepository Certificates { get; set; }
        IEducationRepository Educations { get; set; }
        IEmploymentRepository Employments { get; set; }
        IFeedbackRepository Feedbacks { get; set; }
        IKeyRepository Keys { get; set; }
        ILocationRepository Locations { get; set; }
        IPortfolioRepository Portfolios { get; set; }
        IRoleRepository Roles { get; set; }
        ISkillRepository Skills { get; set; }
        IUserCertificateRepositiry UserCertificates { get; set; }
        IUserRepository Users { get; set; }
        IUserSkillRepository UserSkills { get; set; }
        IUserWorkRepository UserWorks { get; set; }
        IWorkKeyRepository WorkKeys { get; set; }
        IWorkRepository Works { get; set; }
    }
}
