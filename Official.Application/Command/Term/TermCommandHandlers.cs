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
                const int create = 1;
                if (Convert.ToInt32(command.FromYear) + 1 != Convert.ToInt32(command.ToYear))
                {
                    throw new Exception("بازه سال وارد شده غیرمجاز می باشد");
                }

                if (command.No == 1)
                {
                    command.Title = $"نیم سال اول سال تحصیلی {command.ToYear}-{command.FromYear}";
                }
                else if (command.No == 2)
                {
                    command.Title = $"نیم سال دوم سال تحصیلی {command.ToYear}-{command.FromYear}";
                }
                else if (command.No == 3)
                {
                    command.Title = $"دوره تابستان سال تحصیلی {command.ToYear}-{command.FromYear}";
                }
                else
                {
                    throw new Exception("شماره ترم بین 1 تا 3 می باشد");
                }

                var entity = new Domain.Model.CommonEntity.Term.Term(); //Domain.Model.CommonEntity.Term.Term.Instance;
                entity = command.Adapt(entity);

                var isExistsTerm = await _termRepository.IsExistsTerm(entity, create);
                if (isExistsTerm)
                {
                    throw new Exception("این ترم قبلا تعریف شده است");
                }

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
                const int update = 2;
                if (Convert.ToInt32(command.FromYear) + 1 != Convert.ToInt32(command.ToYear))
                {
                    throw new Exception("بازه سال وارد شده غیرمجاز می باشد");
                }

                if (command.No == 1)
                {
                    command.Title = $"نیم سال اول سال تحصیلی {command.ToYear}-{command.FromYear}";
                }
                else if (command.No == 2)
                {
                    command.Title = $"نیم سال دوم سال تحصیلی {command.ToYear}-{command.FromYear}";
                }
                else if (command.No == 3)
                {
                    command.Title = $"دوره تابستان سال تحصیلی {command.ToYear}-{command.FromYear}";
                }
                else
                {
                    throw new Exception("شماره ترم بین 1 تا 3 می باشد");
                }

                var entity = await _termRepository.GetById(command.Id);
                entity = command.Adapt(entity);

                var isExistsTerm = await _termRepository.IsExistsTerm(entity, update);
                if (isExistsTerm)
                {
                    throw new Exception("این ترم قبلا تعریف شده است");
                }

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
                return new DeleteTermCommand(); //DeleteTermCommand.Instance;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
