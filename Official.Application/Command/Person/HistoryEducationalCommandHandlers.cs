using Mapster;
using Official.Application.Contracts.Command.Person.HistoryEducationalCommand;
using Official.Domain.Model.Person.IHistoryEducationalRepository;
using Official.Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Application.Command.Person
{
    public class HistoryEducationalCommandHandlers : ICommandHandler<CreateHistoryEducationalCommand>, ICommandHandler<UpdateHistoryEducationalCommand>, ICommandHandler<DeleteHistoryEducationalCommand>
    {
        private readonly IHistoryEducationalRepository _historyEducationalRepository;
        public HistoryEducationalCommandHandlers(IHistoryEducationalRepository historyEducationalRepository)
        {
            _historyEducationalRepository = historyEducationalRepository;
        }

        public async Task<CreateHistoryEducationalCommand> Handle(CreateHistoryEducationalCommand command)
        {
            try
            {
                var entity = Domain.Model.Person.HistoryEducational.Instance;
                entity = command.Adapt(entity);
                entity = await _historyEducationalRepository.Create(entity);
                var dto = entity.Adapt(command);
                return dto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UpdateHistoryEducationalCommand> Handle(UpdateHistoryEducationalCommand command)
        {
            try
            {
                var entity = await _historyEducationalRepository.GetById(command.Id);
                entity = command.Adapt(entity);
                entity = await _historyEducationalRepository.Update(entity);
                var dto = entity.Adapt(command);
                return dto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<DeleteHistoryEducationalCommand> Handle(DeleteHistoryEducationalCommand command)
        {
            try
            {
                await _historyEducationalRepository.Remove(command.Id);
                return DeleteHistoryEducationalCommand.Instance;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
