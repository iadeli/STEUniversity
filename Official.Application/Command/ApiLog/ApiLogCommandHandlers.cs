using Mapster;
using Official.Domain.Model.Log.IApiLogRepository;
using Official.Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Official.Application.Contracts.Command.Log.ApiLogItem;

namespace Official.Application.Command.ApiLog
{
    public class ApiLogCommandHandlers : ICommandHandler<CreateApiLogCommand, long>
    {
        private readonly IApiLogRepository _apiLogRepository;
        public ApiLogCommandHandlers(IApiLogRepository apiLogRepository)
        {
            _apiLogRepository = apiLogRepository;
        }

        public async Task<long> Handle(CreateApiLogCommand command)
        {
            try
            {
                var entity = new Domain.Model.Log.ApiLog();
                entity = command.Adapt(entity);
                entity = await _apiLogRepository.Create(entity);
                return entity.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
