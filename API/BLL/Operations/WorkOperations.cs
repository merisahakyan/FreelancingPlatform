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

        public UserWorkModel BreakContract(int userId, int workId)
        {
            var userWork = _repositoryManager.UserWorks.GetAll().FirstOrDefault(uw => uw.UserId == userId && uw.WorkId == workId);

            if (userWork == null)
                throw new Exception();
            userWork.DateTo = DateTime.Now;
            _repositoryManager.UserWorks.Update(userWork);
            _repositoryManager.UserWorks.SaveChanges();

            return new UserWorkModel
            {
                Id = userWork.Id,
                DateFrom = userWork.DateFrom,
                DateTo = userWork.DateTo,
                TotalEarned = userWork.TotalEarned,
                UserId = userWork.UserId ?? 0,
                UserRate = userWork.UserRate,
                WorkId = userWork.WorkId ?? 0,
            };
        }

        public WorkModel CreateWork(WorkModel work)
        {
            Work dbWork = new Work();
            dbWork.CreatorId = work.Creator.Id;
            dbWork.Description = work.Description;
            dbWork.Header = work.Header;

            _repositoryManager.Works.Add(dbWork);
            _repositoryManager.Works.SaveChanges();

            work.Id = dbWork.Id;
            return work;
        }

        public void DeleteWork(int id)
        {
            _repositoryManager.Works.Delete(id);
            _repositoryManager.Works.SaveChanges();
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

        public UserWorkModel Hire(int userId, int workId, decimal rate)
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

            return new UserWorkModel
            {
                Id = userWork.Id,
                DateFrom = userWork.DateFrom,
                DateTo = null,
                TotalEarned = 0,
                UserId = userWork.UserId ?? 0,
                UserRate = userWork.UserRate,
                WorkId = userWork.WorkId ?? 0
            };
        }

        public void UpdateWork(WorkModel work)
        {
            Work dbWork = _repositoryManager.Works.GetSingle(work.Id);
            dbWork.Description = work.Description;
            dbWork.Header = work.Header;

            _repositoryManager.Works.Update(dbWork);
        }
    }
}
