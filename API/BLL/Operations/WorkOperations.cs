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
    public class WorkOperations : IWorkOperations
    {
        IRepositoryManager _repositoryManager;
        public WorkOperations(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public void BreakContract(int userId, int workId)
        {
            var userWork = _repositoryManager.UserWorks.GetAll().FirstOrDefault(uw => uw.UserId == userId && uw.WorkId == workId);

            if (userWork == null)
                throw new Exception();
            _repositoryManager.UserWorks.Delete(userWork.Id);
            _repositoryManager.UserWorks.SaveChanges();
        }

        public WorkModel GetWork(int id)
        {
            var work = _repositoryManager.Works.GetSingle(id);
            var creator = _repositoryManager.Users.GetSingle(work.CreatorId.Value);
            var location = _repositoryManager.Locations.GetSingle(creator.LocationId.Value);
            var feedbacks = _repositoryManager.Feedbacks.GetAll().Where(f => f.ReceiverId == creator.Id);
            var workKeys = _repositoryManager.WorkKeys.GetAll().Where(k => k.WorkId == id).Select(wk => wk.KeyId);
            var keys = _repositoryManager.Keys.GetAll().Where(k => workKeys.Any(i => i == k.Id));

            var workModel = new WorkModel()
            {
                Creator = new UserModel
                {
                    Id = creator.Id,
                    Firstname = creator.Firstname,
                    Lastname = creator.Lastname,
                    Location = new LocationModel
                    {
                        Id = location.Id,
                        Country = location.Country
                    },
                    TimePlusUTC = creator.TimePlusUTC,
                },
                Description = work.Description,
                Header = work.Header,
                WorkKeys = keys.Select(k => k.Name).ToList(),
                Feedbacks = feedbacks.Select(f => new FeedbackModel
                {
                    Message = f.Message,
                    Rating = f.Rating
                }).ToList(),
            };

            return workModel;
        }

        public IEnumerable<WorkViewModel> GetWorks(WorkFilterModel filter)
        {
            var works = _repositoryManager.Works.GetAll();

            works = filter.Filter(works);

            var usersList = from w in works
                            let keys = _repositoryManager.WorkKeys.GetAll().Where(wk => wk.WorkId == w.Id).Select(wk => wk.Key.Name)
                            select new WorkViewModel
                            {
                                Description = w.Description,
                                Header = w.Header,
                                WorkKeys = keys.ToList()
                            };
            return usersList;
        }

        public void Hire(int userId, int workId, decimal rate)
        {
            var userWork = new UserWork
            {
                DateFrom = DateTime.Now,
                Active = true,
                UserId = userId,
                UserRate = rate,
                WorkId = workId
            };
            _repositoryManager.UserWorks.Add(userWork);
            _repositoryManager.UserWorks.SaveChanges();
        }
    }
}
