using Official.Application.Contracts.Command.User;
using Official.Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Official.Domain.Model.Security;
using Official.Domain.Model.Security.ISecurityRepository;
using Mapster;
using Official.Application.Contracts.Command.Security;
using Official.Application.Contracts.Command.Person.PersonCommand;
using Official.Domain.Model.Authorization;

namespace Official.Application.Command.User
{
    public class SecurityCommandHandlers : ICommandHandler<LoginCommand, JwtTokenDto>, ICommandHandler<string, JwtTokenDto>, ICommandHandler<CreateUserCommand, bool>
        , ICommandHandler<CreateRoleCommand, bool>, ICommandHandler<CreateRoleClaimCommand, int>
    {
        private readonly ISecurityRepository _securityRepository;
        private readonly IJwtRepository _jwtRepository;
        public SecurityCommandHandlers(ISecurityRepository securityRepository, IJwtRepository jwtRepository)
        {
            _securityRepository = securityRepository;
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

                var isLogin = await _securityRepository.Login(command.UserName.Trim(), command.Password.Trim());

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

        public async Task<bool> Handle(CreateUserCommand command)
        {
            try
            {
                _securityRepository.BeginTransaction();

                var isExistsUser = await _securityRepository.IsExistsUserName(command.UserName.Trim());
                if (isExistsUser)
                    throw new Exception("این نام کاربری قبلا ثبت شده است");

                var succeeded = await _securityRepository.CreateUser(command.UserName.Trim(), command.Password.Trim(), command.PersonId);

                if (succeeded)
                {
                    var userId = await _securityRepository.GetUserIdByUserNameAsync(command.UserName.Trim());
                    await _securityRepository.CreateUserRoleAsync(userId, command.RoleIds);
                }

                _securityRepository.Commit();

                return succeeded;
            }
            catch (Exception e)
            {
                _securityRepository.Rollback();
                throw e;
            }
        }

        public async Task<bool> Handle(CreateRoleCommand command)
        {
            try
            {
                _securityRepository.BeginTransaction();

                var isExistsRole = await _securityRepository.IsExistsRoleNameAsync(command.Name.Trim());
                if (isExistsRole)
                    throw new Exception("این گروه کاربری قبلا ثبت شده است");

                var succeeded = await _securityRepository.CreateRoleAsync(command.Name);
                if (succeeded)
                {
                    var roleId = await _securityRepository.GetRoleIdByRoleNameAsync(command.Name.Trim());
                    await _securityRepository.CreateRoleUserAsync(roleId, command.UserIds);
                }

                _securityRepository.Commit();

                return succeeded;
            }
            catch (Exception e)
            {
                _securityRepository.Rollback();
                throw e;
            }
        }

        public async Task<int> Handle(CreateRoleClaimCommand command)
        {
            try
            {
                var roleClaimTransfer = new RoleClaimTransfer();
                roleClaimTransfer = command.Adapt(roleClaimTransfer);
                var rowsAffected = await _securityRepository.CreateRoleClaims(roleClaimTransfer);
                return rowsAffected;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
