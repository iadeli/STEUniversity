using Mapster;
using Official.Application.Contracts.Command.Person.HistoryEducationalCommand;
using Official.Domain.Model.Person.IHistoryEducationalRepository;
using Official.Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Official.Domain.Model.Person;

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
                var historyEducational = new HistoryEducational(); //Domain.Model.Person.HistoryEducational.Instance;
                var degreeAttache = new DegreeAttach(); //Domain.Model.Person.DegreeAttach.Instance;

                historyEducational = command.Adapt(historyEducational);
                degreeAttache = command.Adapt(degreeAttache);

                historyEducational.DegreeAttaches.Add(degreeAttache);

                historyEducational = await _historyEducationalRepository.Create(historyEducational);

                command = historyEducational.Adapt(command);
                return command;
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
                _historyEducationalRepository.BeginTransaction();

                var entity = await _historyEducationalRepository.GetById(command.Id);
                entity = command.Adapt(entity);

                var degreeAttach = new DegreeAttach(); //DegreeAttach.Instance;
                degreeAttach = command.Adapt(degreeAttach);

                await _historyEducationalRepository.RemoveDegreeAttach(entity.Id);

                entity.DegreeAttaches.Add(degreeAttach);

                entity = await _historyEducationalRepository.Update(entity);
                command = entity.Adapt(command);

                _historyEducationalRepository.Commit();

                return command;
            }
            catch (Exception e)
            {
                _historyEducationalRepository.Rollback();
                throw e;
            }
        }

        public async Task<DeleteHistoryEducationalCommand> Handle(DeleteHistoryEducationalCommand command)
        {
            try
            {
                await _historyEducationalRepository.Remove(command.Id);
                return new DeleteHistoryEducationalCommand(); //DeleteHistoryEducationalCommand.Instance;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
