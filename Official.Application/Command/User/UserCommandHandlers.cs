using Official.Application.Contracts.Command.User;
using Official.Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Official.Domain.Model.Security;
using Official.Domain.Model.Security.ISecurityRepository;
using Mapster;

namespace Official.Application.Command.User
{
    public class UserCommandHandlers : ICommandHandler<LoginCommand, JwtTokenDto>, ICommandHandler<CreateUserCommand, bool>, ICommandHandler<string, JwtTokenDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IJwtRepository _jwtRepository;
        public UserCommandHandlers(IUserRepository userRepository, IJwtRepository jwtRepository)
        {
            _userRepository = userRepository;
            _jwtRepository = jwtRepository;
        }

        public async Task<JwtTokenDto> Handle(LoginCommand command)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(command.UserName))
                    throw new Exception("نام کاربری نمی تواند خالی باشد");

                if (string.IsNullOrWhiteSpace(command.Password))
                    throw new Exception("کلمه عبور نمی تواند خالی باشد");

                var isLogin = await _userRepository.Login(command.UserName.Trim(), command.Password.Trim());

                if (!isLogin)
                    throw new Exception("نام کاربری یا کلمه عبور اشتباه است");

                var jwtToken = await _jwtRepository.CreateToken(command.UserName);
                var dto = new JwtTokenDto()
                {
                    Expiration = jwtToken.Expiration,
                    Token = jwtToken.Token
                };
                return dto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> Handle(CreateUserCommand command)
        {
            try
            {
                var isExistsUser = await _userRepository.IsExistsUserName(command.UserName.Trim());
                if (isExistsUser)
                {
                    throw new Exception("این نام کاربری قبلا ثبت شده است");
                }

                var succeeded = await _userRepository.Create(command.UserName.Trim(), command.Password.Trim(), command.PersonId);
                return succeeded;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<JwtTokenDto> Handle(string token)
        {
            try
            {
                var jwtToken = await _jwtRepository.RefreshToken(token);
                var dto = new JwtTokenDto()
                {
                    Expiration = jwtToken.Expiration,
                    Token = jwtToken.Token
                };
                return dto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
