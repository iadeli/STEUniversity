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
    public class TermCommandHandlers : ICommandHandler<CreateTermCommand, long>, ICommandHandler<UpdateTermCommand, long>, ICommandHandler<DeleteTermCommand, int>
    {
        private readonly ITermRepository _termRepository;
        public TermCommandHandlers(ITermRepository termRepository)
        {
            _termRepository = termRepository;
        }

        public async Task<long> Handle(CreateTermCommand command)
        {
            try
            {
                const int create = 1;

                var entity = new Domain.Model.CommonEntity.Term.Term();
                entity = command.Adapt(entity);

                if (Convert.ToInt32(entity.FromYear) + 1 != Convert.ToInt32(entity.ToYear))
                {
                    throw new Exception("بازه سال وارد شده غیرمجاز می باشد");
                }

                if (entity.No == 1)
                {
                    entity.Title = $"نیم سال اول سال تحصیلی {entity.ToYear}-{entity.FromYear}";
                }
                else if (entity.No == 2)
                {
                    entity.Title = $"نیم سال دوم سال تحصیلی {entity.ToYear}-{entity.FromYear}";
                }
                else if (entity.No == 3)
                {
                    entity.Title = $"دوره تابستان سال تحصیلی {entity.ToYear}-{entity.FromYear}";
                }
                else
                {
                    throw new Exception("شماره ترم بین 1 تا 3 می باشد");
                }

                var isExistsTerm = await _termRepository.IsExistsTerm(entity, create);
                if (isExistsTerm)
                {
                    throw new Exception("این ترم قبلا تعریف شده است");
                }

                entity = await _termRepository.Create(entity);
                return entity.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<long> Handle(UpdateTermCommand command)
        {
            try
            {
                const int update = 2;

                var entity = await _termRepository.GetById(command.Id);
                entity = command.Adapt(entity);

                if (Convert.ToInt32(entity.FromYear) + 1 != Convert.ToInt32(entity.ToYear))
                {
                    throw new Exception("بازه سال وارد شده غیرمجاز می باشد");
                }

                if (entity.No == 1)
                {
                    entity.Title = $"نیم سال اول سال تحصیلی {entity.ToYear}-{entity.FromYear}";
                }
                else if (entity.No == 2)
                {
                    entity.Title = $"نیم سال دوم سال تحصیلی {entity.ToYear}-{entity.FromYear}";
                }
                else if (entity.No == 3)
                {
                    entity.Title = $"دوره تابستان سال تحصیلی {entity.ToYear}-{entity.FromYear}";
                }
                else
                {
                    throw new Exception("شماره ترم بین 1 تا 3 می باشد");
                }

                var isExistsTerm = await _termRepository.IsExistsTerm(entity, update);
                if (isExistsTerm)
                {
                    throw new Exception("این ترم قبلا تعریف شده است");
                }

                entity = await _termRepository.Update(entity);
                return entity.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> Handle(DeleteTermCommand command)
        {
            try
            {
                return await _termRepository.Remove(command.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
