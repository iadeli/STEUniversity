using System;
using System.Threading.Tasks;
using Mapster;
using Official.Application.Contracts.Command.Person.HireStageCommand;
using Official.Domain.Model.Person;
using Official.Domain.Model.Person.IHireStageRepository;
using Official.Framework.Application;

namespace Official.Application.Command.Person
{
    public class HireStageCommandHandlers : ICommandHandler<CreateHireStageCommand, long>, ICommandHandler<UpdateHireStageCommand, long>, ICommandHandler<DeleteHireStageCommand, int>
    {
        private readonly IHireStageRepository _hireStageRepository;
        public HireStageCommandHandlers(IHireStageRepository hireStageRepository)
        {
            _hireStageRepository = hireStageRepository;
        }

        public async Task<long> Handle(CreateHireStageCommand command)
        {
            try
            {
                var entity = new HireStage(); //Domain.Model.Person.HireStage.Instance;
                entity = command.Adapt(entity);

                const int create = 1;
                var isExistsHireStage = await _hireStageRepository.IsExistsHireStage(entity, create);
                if (isExistsHireStage)
                    throw new Exception("وضعیت استخدامی تکراری است");

                entity = await _hireStageRepository.Create(entity);
                return entity.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<long> Handle(UpdateHireStageCommand command)
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
                return entity.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Handle(DeleteHireStageCommand command)
        {
            try
            {
                var result = await _hireStageRepository.Remove(command.Id);
                return result;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
