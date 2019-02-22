using Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models.FilterModels
{
    public class WorkFilterModel : FilterBase<Work>
    {
        public string Header { get; set; }
        public string Description { get; set; }
        public int? CreatorId { get; set; }
        public int? MinRate { get; set; }
        public int? MaxRate { get; set; }
        public List<string> WorkKeys { get; set; }
        public override IQueryable<Work> Filter(IQueryable<Work> query)
        {
            if (!string.IsNullOrEmpty(Header))
            {
                query = query.Where(q => q.Header.Contains(Header));
            }
            if (!string.IsNullOrEmpty(Description))
            {
                query = query.Where(q => q.Header.Contains(Description));
            }
            if (CreatorId.HasValue)
            {
                query = query.Where(q => q.CreatorId == CreatorId);
            }
            if (MinRate.HasValue)
            {
                query = query.Where(q => q.Creator.ReceivedFeedbacks.Average(f => f.Rating) >= MinRate);
            }
            if (MaxRate.HasValue)
            {
                query = query.Where(q => q.Creator.ReceivedFeedbacks.Average(f => f.Rating) <= MaxRate);
            }
            if (WorkKeys != null && WorkKeys.Count > 0)
            {
                foreach (var key in WorkKeys)
                {
                    query = query.Where(q => q.WorkKeys.Select(wk => wk.Key.Name).Contains(key));
                }
            }
            return base.Filter(query);
        }
    }
}
