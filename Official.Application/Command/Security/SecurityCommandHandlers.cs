using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Official.Application.Contracts.Command.Security;
using Official.Domain.Model.Authorization;
using Official.Domain.Model.Security.ISecurityRepository;
using Official.Framework.Application;

namespace Official.Application.Command.Security
{
    public class SecurityCommandHandlers : ICommandHandler<LoginCommand, JwtTokenDto>, ICommandHandler<string, JwtTokenDto>
        , ICommandHandler<List<CreateRoleClaimCommand>, bool>
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

        public async Task<bool> HandleAsync(List<CreateRoleClaimCommand> command)
        {
            try
            {
                _securityRepository.BeginTransaction();

                var addRoleClaimList = new List<RoleClaimTransfer>();
                var removeRoleClaimList = new List<RoleClaimTransfer>();

                var roleClaimType = command.Select(a => a.ClaimType).FirstOrDefault();
                if (roleClaimType == "ControlerInfoId")
                {
                    await PrepareRoleClaimList(command, addRoleClaimList, removeRoleClaimList);
                }
                if (roleClaimType == "ProvinceId" || roleClaimType == "PositionId")
                {
                    PrepareRoleClaimList2(command, addRoleClaimList, removeRoleClaimList);
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

        private static void PrepareRoleClaimList2(List<CreateRoleClaimCommand> command, List<RoleClaimTransfer> addRoleClaimList, List<RoleClaimTransfer> removeRoleClaimList)
        {
            foreach (var roleClaim in command)
            {
                var roleClaimDto = new RoleClaimTransfer()
                {
                    RoleId = roleClaim.RoleId,
                    ClaimType = roleClaim.ClaimType,
                    ClaimValue = roleClaim.ClaimValue.ToString()
                };
                if (roleClaim.Checked)
                    addRoleClaimList.Add(roleClaimDto);
                else
                    removeRoleClaimList.Add(roleClaimDto);
            }
        }

        private async Task PrepareRoleClaimList(List<CreateRoleClaimCommand> command, List<RoleClaimTransfer> addRoleClaimList, List<RoleClaimTransfer> removeRoleClaimList)
        {
            foreach (var roleClaim in command)
            {
                var addControllerIds = _securityRepository.GetControllerIdByType(roleClaim.Entity, "AddPolicy");
                var deleteControllerIds = _securityRepository.GetControllerIdByType(roleClaim.Entity, "DeletePolicy");
                var editControllerIds = _securityRepository.GetControllerIdByType(roleClaim.Entity, "EditPolicy");
                var viewControllerIds = _securityRepository.GetControllerIdByType(roleClaim.Entity, "ViewPolicy");

                foreach (var controllerId in addControllerIds)
                {
                    var roleClaimDto = new RoleClaimTransfer()
                    {
                        RoleId = roleClaim.RoleId,
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
                    var roleClaimDto = new RoleClaimTransfer()
                    {
                        RoleId = roleClaim.RoleId,
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
                    var roleClaimDto = new RoleClaimTransfer()
                    {
                        RoleId = roleClaim.RoleId,
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
                    var roleClaimDto = new RoleClaimTransfer()
                    {
                        RoleId = roleClaim.RoleId,
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

    }
}
