using Mapster;
using Official.Application.Contracts.Command.Person;
using Official.Domain.Model.Person.EducationalInfoRepository;
using Official.Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Application.Command.Person
{
    public class EducationalInfoCommandHandlers : ICommandHandler<CreateEducationalInfoCommand>, ICommandHandler<UpdateEducationalInfoCommand>, ICommandHandler<DeleteEducationalInfoCommand>
    {
        private readonly IEducationalInfoRepository _educationalInfoRepository;
        public EducationalInfoCommandHandlers(IEducationalInfoRepository educationalInfoRepository)
        {
            _educationalInfoRepository = educationalInfoRepository;
        }

        public async Task<CreateEducationalInfoCommand> Handle(CreateEducationalInfoCommand command)
        {
            try
            {
                var entity = Domain.Model.Person.EducationalInfo.Instance;
                entity = command.Adapt(entity);
                entity = await _educationalInfoRepository.Create(entity);
                var dto = entity.Adapt(command);
                return dto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UpdateEducationalInfoCommand> Handle(UpdateEducationalInfoCommand command)
        {
            try
            {
                var entity = _educationalInfoRepository.GetById(command.Id);
                entity = command.Adapt(entity);
                entity = await _educationalInfoRepository.Update(entity);
                var dto = entity.Adapt(command);
                return dto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<DeleteEducationalInfoCommand> Handle(DeleteEducationalInfoCommand command)
        {
            try
            {
                await _educationalInfoRepository.Remove(command.Id);
                return DeleteEducationalInfoCommand.Instance;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
