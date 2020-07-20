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
    public class HistoryEducationalCommandHandlers : ICommandHandler<CreateHistoryEducationalCommand, long>, ICommandHandler<UpdateHistoryEducationalCommand, long>, ICommandHandler<DeleteHistoryEducationalCommand, int>
    {
        private readonly IHistoryEducationalRepository _historyEducationalRepository;
        public HistoryEducationalCommandHandlers(IHistoryEducationalRepository historyEducationalRepository)
        {
            _historyEducationalRepository = historyEducationalRepository;
        }

        public async Task<long> HandleAsync(CreateHistoryEducationalCommand command)
        {
            try
            {
                var historyEducational = new HistoryEducational(); //Domain.Model.Person.HistoryEducational.Instance;
                var degreeAttache = new DegreeAttach(); //Domain.Model.Person.DegreeAttach.Instance;

                historyEducational = command.Adapt(historyEducational);
                degreeAttache = command.Adapt(degreeAttache);

                historyEducational.DegreeAttaches.Add(degreeAttache);

                historyEducational = await _historyEducationalRepository.Create(historyEducational);
                return historyEducational.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<long> HandleAsync(UpdateHistoryEducationalCommand command)
        {
            try
            {
                _historyEducationalRepository.BeginTransaction();

                var entity = await _historyEducationalRepository.GetById(command.Id);
                entity = command.Adapt(entity);

                var degreeAttach = new DegreeAttach(); //DegreeAttach.Instance;
                degreeAttach = command.Adapt(degreeAttach);
                degreeAttach.Id = 0;
                degreeAttach.HistoryEducationalId = entity.Id;

                await _historyEducationalRepository.RemoveDegreeAttach(entity.Id);

                entity.DegreeAttaches.Add(degreeAttach);

                entity = await _historyEducationalRepository.Update(entity);
                _historyEducationalRepository.Commit();
                return entity.Id;
            }
            catch (Exception e)
            {
                _historyEducationalRepository.Rollback();
                throw e;
            }
        }

        public async Task<int> HandleAsync(DeleteHistoryEducationalCommand command)
        {
            try
            {
                return await _historyEducationalRepository.Remove(command.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
