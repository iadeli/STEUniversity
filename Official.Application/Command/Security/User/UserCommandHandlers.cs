using Official.Application.Contracts.Command.Security.User;
using Official.Application.Contracts.Command.User;
using Official.Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Application.Command.Security
{
    public class UserCommandHandlers : ICommandHandler<CreateUserCommand, long>, ICommandHandler<UpdateUserCommand, long>, ICommandHandler<RemoveUserCommand, int>
    {
        private readonly IUserRepository _userRepository;
        public UserCommandHandlers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<long> Handle(CreateUserCommand command)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<long> Handle(UpdateUserCommand command)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public Task<int> Handle(RemoveUserCommand command)
        {
            try
            {

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
