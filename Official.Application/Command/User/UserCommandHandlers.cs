using Official.Application.Contracts.Command.User;
using Official.Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Official.Domain.Model.Security;
using Official.Domain.Model.Security.ISecurityRepository;

namespace Official.Application.Command.User
{
    public class UserCommandHandlers : ICommandHandler<LoginCommand>, ICommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtRepository _jwtRepository;
        public UserCommandHandlers(IUserRepository userRepository, IJwtRepository jwtRepository)
        {
            _userRepository = userRepository;
            _jwtRepository = jwtRepository;
        }

        public async Task<LoginCommand> Handle(LoginCommand command)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(command.UserName))
                {
                    throw new Exception("نام کاربری نمی تواند خالی باشد");
                }

                if (string.IsNullOrWhiteSpace(command.Password))
                {
                    throw new Exception("کلمه عبور نمی تواند خالی باشد");
                }

                command.IsLogin = await _userRepository.Login(command.UserName.Trim(), command.Password.Trim());

                if (!(command.IsLogin ?? false))
                {
                    throw new Exception("نام کاربری یا کلمه عبور اشتباه است");
                }

                var jwtToken = await _jwtRepository.CreateToken(command.UserName);
                command.Token = jwtToken.Token;
                command.Expiration = jwtToken.Expiration;

                return command;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<CreateUserCommand> Handle(CreateUserCommand command)
        {
            try
            {
                var isExistsUser = await _userRepository.IsExistsUserName(command.UserName.Trim());
                if (isExistsUser)
                {
                    throw new Exception("این نام کاربری قبلا ثبت شده است");
                }

                command.Succeeded = await _userRepository.Create(command.UserName.Trim(), command.Password.Trim(), command.PersonId);
                return command;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
