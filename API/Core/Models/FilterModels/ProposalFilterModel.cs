using Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models.FilterModels
{
    public class ProposalFilterModel : FilterBase<Proposal>
    {
        public double? MinRate { get; set; }
        public double? MaxRate { get; set; }
        public long? MinDaysCount { get; set; }
        public long? MaxDaysCount { get; set; }
        public DateTime? MinDate { get; set; }
        public DateTime? MaxDate { get; set; }
        public int? WorkId { get; set; }

        public override IQueryable<Proposal> Filter(IQueryable<Proposal> query)
        {
            if (MinRate.HasValue)
            {
                query = query.Where(q => q.Rate >= MinRate);
            }
            if (MaxRate.HasValue)
            {
                query = query.Where(q => q.Rate <= MaxRate);
            }
            if (MinDaysCount.HasValue)
            {
                query = query.Where(q => q.DaysCount >= MinDaysCount);
            }
            if (MaxDaysCount.HasValue)
            {
                query = query.Where(q => q.Rate <= MaxDaysCount);
            }
            if (MinDate.HasValue)
            {
                query = query.Where(q => q.Date >= MinDate);
            }
            if (MaxDate.HasValue)
            {
                query = query.Where(q => q.Date >= MaxDate);
            }
            if (WorkId.HasValue)
            {
                query = query.Where(q => q.WorkId == WorkId);
            }
            return base.Filter(query);
        }
    }
}
