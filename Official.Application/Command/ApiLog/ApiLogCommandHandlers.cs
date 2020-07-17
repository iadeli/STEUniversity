using Mapster;
using Official.Application.Contracts.Command.Log.ApiLog;
using Official.Domain.Model.Log.IApiLogRepository;
using Official.Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Application.Command.ApiLog
{
    public class ApiLogCommandHandlers : ICommandHandler<CreateApiLogCommand>
    {
        private readonly IApiLogRepository _apiLogRepository;
        public ApiLogCommandHandlers(IApiLogRepository apiLogRepository)
        {
            _apiLogRepository = apiLogRepository;
        }

        public async Task<CreateApiLogCommand> Handle(CreateApiLogCommand command)
        {
            try
            {
                var entity = new Domain.Model.Log.ApiLog();
                entity = command.Adapt(entity);
                entity = await _apiLogRepository.Create(entity);
                command = entity.Adapt(command);
                return command;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
