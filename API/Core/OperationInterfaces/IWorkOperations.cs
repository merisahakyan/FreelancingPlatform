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
        void Hire(int userId, int workId, decimal rate);
        void BreakContract(int userId, int workId);
    }
}
