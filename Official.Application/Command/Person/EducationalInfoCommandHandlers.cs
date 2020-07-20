using Mapster;
using Official.Application.Contracts.Command.Person;
using Official.Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Official.Application.Contracts.Command.Person.EducationalInfoCommand;
using Official.Domain.Model.Person.IEducationalInfoRepository;

namespace Official.Application.Command.Person
{
    public class EducationalInfoCommandHandlers : ICommandHandler<CreateEducationalInfoCommand, long>, ICommandHandler<UpdateEducationalInfoCommand, long>, ICommandHandler<DeleteEducationalInfoCommand, int>
    {
        private readonly IEducationalInfoRepository _educationalInfoRepository;
        public EducationalInfoCommandHandlers(IEducationalInfoRepository educationalInfoRepository)
        {
            _educationalInfoRepository = educationalInfoRepository;
        }

        public async Task<long> HandleAsync(CreateEducationalInfoCommand command)
        {
            try
            {
                var entity = new Domain.Model.Person.EducationalInfo(); //Domain.Model.Person.EducationalInfo.Instance;
                entity = command.Adapt(entity);

                const int create = 1;
                var isExistsEducationalInfo = await _educationalInfoRepository.IsExistsEducationalInfo(entity, create);
                if (isExistsEducationalInfo)
                    throw new Exception("اطلاعات آموزشی وارد شده تکراری است");

                entity = await _educationalInfoRepository.Create(entity);
                return entity.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<long> HandleAsync(UpdateEducationalInfoCommand command)
        {
            try
            {
                var entity = await _educationalInfoRepository.GetById(command.Id);
                entity = command.Adapt(entity);

                const int update = 2;
                var isExistsEducationalInfo = await _educationalInfoRepository.IsExistsEducationalInfo(entity, update);
                if (isExistsEducationalInfo)
                    throw new Exception("اطلاعات آموزشی وارد شده تکراری است");

                entity = await _educationalInfoRepository.Update(entity);
                return entity.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> HandleAsync(DeleteEducationalInfoCommand command)
        {
            try
            {
                return await _educationalInfoRepository.Remove(command.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
