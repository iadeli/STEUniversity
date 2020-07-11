using System;
using System.Threading.Tasks;

namespace Official.Domain.Model.Person.IEducationalInfoRepository
{
    public interface IEducationalInfoRepository : IDisposable
    {
        Task<EducationalInfo> Create(EducationalInfo educationalInfo);
        Task<EducationalInfo> Update(EducationalInfo educationalInfo);
        Task Remove(long id);
        Task<EducationalInfo> GetById(long id);
        Task<bool> IsExistsEducationalInfo(EducationalInfo entity, int update);
    }
}
