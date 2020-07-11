using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Official.Application.Contracts.Command.Person.EducationalInfoCommand;
using Official.Application.Contracts.Command.Person.HireStageCommand;
using Official.Domain.Model.Person.IHireStageRepository;
using Official.Framework.Application;

namespace Official.Application.Command.Person
{
    public class HireStageCommandHandlers : ICommandHandler<CreateHireStageCommand>, ICommandHandler<UpdateHireStageCommand>, ICommandHandler<DeleteHireStageCommand>
    {
        private readonly IHireStageRepository _hireStageRepository;
        public HireStageCommandHandlers(IHireStageRepository hireStageRepository)
        {
            _hireStageRepository = hireStageRepository;
        }

        public async Task<CreateHireStageCommand> Handle(CreateHireStageCommand command)
        {
            try
            {
                var entity = new Domain.Model.Person.HireStage(); //Domain.Model.Person.HireStage.Instance;
                entity = command.Adapt(entity);

                const int create = 1;
                var isExistsHireStage = await _hireStageRepository.IsExistsHireStage(entity, create);
                if (isExistsHireStage)
                    throw new Exception("وضعیت استخدامی تکراری است");

                entity = await _hireStageRepository.Create(entity);
                command = entity.Adapt(command);
                return command;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UpdateHireStageCommand> Handle(UpdateHireStageCommand command)
        {
            try
            {
                var entity = await _hireStageRepository.GetById(command.Id);
                entity = command.Adapt(entity);

                const int update = 2;
                var isExistsHireStage = await _hireStageRepository.IsExistsHireStage(entity, update);
                if (isExistsHireStage)
                    throw new Exception("وضعیت استخدامی تکراری است");

                entity = await _hireStageRepository.Update(entity);
                command = entity.Adapt(command);
                return command;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<DeleteHireStageCommand> Handle(DeleteHireStageCommand command)
        {
            try
            {
                await _hireStageRepository.Remove(command.Id);
                return new DeleteHireStageCommand(); //DeleteHireStageCommand.Instance;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
