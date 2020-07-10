using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Mapster;
using Official.Application.Contracts.Command.Term;
using Official.Application.Contracts.Command.User;
using Official.Domain.Model.CommonEntity.Term.ITermRepository;
using Official.Framework.Application;

namespace Official.Application.Command.Term
{
    public class TermCommandHandlers : ICommandHandler<CreateTermCommand>, ICommandHandler<UpdateTermCommand>, ICommandHandler<DeleteTermCommand>
    {
        private readonly ITermRepository _termRepository;
        public TermCommandHandlers(ITermRepository termRepository)
        {
            _termRepository = termRepository;
        }

        public async Task<CreateTermCommand> Handle(CreateTermCommand command)
        {
            try
            {
                var entity = Domain.Model.CommonEntity.Term.Term.Instance;
                entity = command.Adapt(entity);
                entity = await _termRepository.Create(entity);
                command = entity.Adapt(command);
                return command;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UpdateTermCommand> Handle(UpdateTermCommand command)
        {
            try
            {
                var entity = await _termRepository.GetById(command.Id);
                entity = command.Adapt(entity);
                entity = await _termRepository.Update(entity);
                command = entity.Adapt(command);
                return command;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<DeleteTermCommand> Handle(DeleteTermCommand command)
        {
            try
            {
                await _termRepository.Remove(command.Id);
                return DeleteTermCommand.Instance;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
