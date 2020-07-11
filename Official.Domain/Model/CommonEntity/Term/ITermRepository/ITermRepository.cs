using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Official.Domain.Model.Person;

namespace Official.Domain.Model.CommonEntity.Term.ITermRepository
{
    public interface ITermRepository : IDisposable
    {
        Task<Term> Create(Term educationalInfo);
        Task<Term> Update(Term educationalInfo);
        Task Remove(long id);
        Task<Term> GetById(long id);
        Task<bool> IsExistsTerm(Term term, int create);
    }
}
