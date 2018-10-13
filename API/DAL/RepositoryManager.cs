using Core;
using Core.Database;
using Core.RepositoryInterfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class RepositoryManager : IRepositoryManager
    {
        private ApplicationDbContext _context;
        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
        }
        private ICertificateRepository _certificates;
        public ICertificateRepository Certificates => _certificates = new CertificateRepository(_context);

        private IEducationRepository _educations;
        public IEducationRepository Educations => _educations = new EducationRepository(_context);

        private IEmploymentRepository _employments;
        public IEmploymentRepository Employments => _employments = new EploymentRepository(_context);

        private IFeedbackRepository _feedbacks;
        public IFeedbackRepository Feedbacks => _feedbacks = new FeedbackRepository(_context);

        private IKeyRepository _keys;
        public IKeyRepository Keys => _keys = new KeyRepository(_context);

        private ILocationRepository _locations;
        public ILocationRepository Locations => _locations = new LocationRepository(_context);

        private IPortfolioRepository _portfolios;
        public IPortfolioRepository Portfolios => _portfolios = new PortfolioRepository(_context);

        private IRoleRepository _roles;
        public IRoleRepository Roles => _roles = new RoleRepository(_context);

        private ISkillRepository _skills;
        public ISkillRepository Skills => _skills = new SkillRepository(_context);

        private IUserCertificateRepositiry _userCertificates;
        public IUserCertificateRepositiry UserCertificates => _userCertificates = new UserCertificateRepository(_context);

        private IUserRepository _users;
        public IUserRepository Users => _users = new UserRepository(_context);

        private IUserSkillRepository _userSkills;
        public IUserSkillRepository UserSkills => _userSkills = new UserSkillRepository(_context);

        private IUserWorkRepository _userWorks;
        public IUserWorkRepository UserWorks => _userWorks = new UserWorkRepository(_context);

        private IWorkKeyRepository _workKeys;
        public IWorkKeyRepository WorkKeys => _workKeys = new WorkKeyRepository(_context);

        private IWorkRepository _works;
        public IWorkRepository Works => _works = new WorkRepository(_context);


    }
}
