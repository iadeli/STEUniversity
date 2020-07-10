using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Domain.Model.Person.IHistoryEducationalRepository
{
    public interface IHistoryEducationalRepository : IDisposable
    {
        Task<HistoryEducational> Create(HistoryEducational educationalInfo);
        Task<HistoryEducational> Update(HistoryEducational educationalInfo);
        Task Remove(long id);
        Task<HistoryEducational> GetById(long id);
    }
}
