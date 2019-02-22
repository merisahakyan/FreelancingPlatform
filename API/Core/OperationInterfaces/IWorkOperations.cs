using Core.Database;
using Core.Models.BusinessModels;
using Core.Models.FilterModels;
using Core.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.OperationInterfaces
{
    public interface IWorkOperations
    {
        IEnumerable<WorkViewModel> GetWorks(WorkFilterModel filter);
        WorkModel GetWork(int id);
        UserWorkModel Hire(int userId, int workId, decimal rate);
        UserWorkModel BreakContract(int userId, int workId);
        WorkModel CreateWork(WorkModel work);
        void UpdateWork(WorkModel work);
        void DeleteWork(int id);
    }
}
