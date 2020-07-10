using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Domain.Model.Person.EducationalInfoRepository
{
    public interface IEducationalInfoRepository : IDisposable
    {
        Task<EducationalInfo> Create(EducationalInfo educationalInfo);
        Task<EducationalInfo> Update(EducationalInfo educationalInfo);
        Task Remove(long id);
        Task<EducationalInfo> GetById(long id);
    }
}
