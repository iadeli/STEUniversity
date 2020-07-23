using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Official.Application.Contracts.Command.Security;
using Official.Application.Contracts.Command.Security.User;
using Official.Domain.Model.Authorization;
using Official.Domain.Model.Security.ISecurityRepository;
using Official.Framework.Application;

namespace Official.Application.Command.Security
{
    public class SecurityCommandHandlers : ICommandHandler<LoginCommand, JwtTokenDto>, ICommandHandler<string, JwtTokenDto>
        , ICommandHandler<CreateRoleClaimCommand, bool>, ICommandHandler<CreateUserClaimCommand, bool>
    {
        private readonly ISecurityRepository _securityRepository;
        private readonly IJwtRepository _jwtRepository;
        public SecurityCommandHandlers(ISecurityRepository securityRepository, IJwtRepository jwtRepository)
        {
            _securityRepository = securityRepository;
            _jwtRepository = jwtRepository;
        }

        public async Task<JwtTokenDto> HandleAsync(LoginCommand command)
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

        public async Task<JwtTokenDto> HandleAsync(string token)
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

        public async Task<bool> HandleAsync(CreateRoleClaimCommand command)
        {
            try
            {
                _securityRepository.BeginTransaction();

                var dto = command.CreateRoleClaimDtos;

                var addRoleClaimList = new List<ClaimTransfer>();
                var removeRoleClaimList = new List<ClaimTransfer>();

                var roleClaimType = dto.Select(a => a.ClaimType).FirstOrDefault();
                if (roleClaimType == "ControllerInfoId")
                {
                    await PrepareRoleClaimList(dto, addRoleClaimList, removeRoleClaimList);
                }

                await _securityRepository.RemoveRoleClaims(removeRoleClaimList);
                await _securityRepository.CreateRoleClaims(addRoleClaimList);

                _securityRepository.Commit();

                return true;
            }
            catch (Exception e)
            {
                _securityRepository.Rollback();
                throw e;
            }
        }

        private static void PrepareUserClaimList(List<CreateUserClaimDto> command, List<ClaimTransfer> addRoleClaimList, List<ClaimTransfer> removeRoleClaimList)
        {
            foreach (var userClaim in command)
            {
                var userClaimDto = new ClaimTransfer()
                {
                    UserOrRoleId = userClaim.UserId,
                    ClaimType = userClaim.ClaimType,
                    ClaimValue = userClaim.ClaimValue.ToString()
                };
                if (userClaim.Checked)
                    addRoleClaimList.Add(userClaimDto);
                else
                    removeRoleClaimList.Add(userClaimDto);
            }
        }

        private async Task PrepareRoleClaimList(List<CreateRoleClaimDto> command, List<ClaimTransfer> addRoleClaimList, List<ClaimTransfer> removeRoleClaimList)
        {
            foreach (var roleClaim in command)
            {
                var addControllerIds = _securityRepository.GetControllerIdByType(roleClaim.Entity, "AddPolicy");
                var deleteControllerIds = _securityRepository.GetControllerIdByType(roleClaim.Entity, "DeletePolicy");
                var editControllerIds = _securityRepository.GetControllerIdByType(roleClaim.Entity, "EditPolicy");
                var viewControllerIds = _securityRepository.GetControllerIdByType(roleClaim.Entity, "ViewPolicy");

                foreach (var controllerId in addControllerIds)
                {
                    var roleClaimDto = new ClaimTransfer()
                    {
                        UserOrRoleId = roleClaim.RoleId,
                        ClaimType = roleClaim.ClaimType,
                        ClaimValue = controllerId.ToString()
                    };
                    if ((roleClaim.AddPolicy ?? false) == true)
                        addRoleClaimList.Add(roleClaimDto);
                    else
                        removeRoleClaimList.Add(roleClaimDto);
                }

                foreach (var controllerId in deleteControllerIds)
                {
                    var roleClaimDto = new ClaimTransfer()
                    {
                        UserOrRoleId = roleClaim.RoleId,
                        ClaimType = roleClaim.ClaimType,
                        ClaimValue = controllerId.ToString()
                    };
                    if ((roleClaim.DeletePolicy ?? false) == true)
                        addRoleClaimList.Add(roleClaimDto);
                    else
                        removeRoleClaimList.Add(roleClaimDto);
                }

                foreach (var controllerId in editControllerIds)
                {
                    var roleClaimDto = new ClaimTransfer()
                    {
                        UserOrRoleId = roleClaim.RoleId,
                        ClaimType = roleClaim.ClaimType,
                        ClaimValue = controllerId.ToString()
                    };
                    if ((roleClaim.EditPolicy ?? false) == true)
                        addRoleClaimList.Add(roleClaimDto);
                    else
                        removeRoleClaimList.Add(roleClaimDto);
                }

                foreach (var controllerId in viewControllerIds)
                {
                    var roleClaimDto = new ClaimTransfer()
                    {
                        UserOrRoleId = roleClaim.RoleId,
                        ClaimType = roleClaim.ClaimType,
                        ClaimValue = controllerId.ToString()
                    };
                    if ((roleClaim.ViewPolicy ?? false) == true)
                        addRoleClaimList.Add(roleClaimDto);
                    else
                        removeRoleClaimList.Add(roleClaimDto);
                }
            }
        }

        public async Task<bool> HandleAsync(CreateUserClaimCommand command)
        {
            try
            {
                _securityRepository.BeginTransaction();

                var dto = command.CreateUserClaimDtos;

                var addUserClaimList = new List<ClaimTransfer>();
                var removeUserClaimList = new List<ClaimTransfer>();

                var userClaimType = dto.Select(a => a.ClaimType).FirstOrDefault();
                if (userClaimType == "ProvinceId" || userClaimType == "PositionId")
                {
                    PrepareUserClaimList(dto, addUserClaimList, removeUserClaimList);
                }

                await _securityRepository.RemoveUserClaims(removeUserClaimList);
                await _securityRepository.CreateUserClaims(addUserClaimList);

                _securityRepository.Commit();

                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
