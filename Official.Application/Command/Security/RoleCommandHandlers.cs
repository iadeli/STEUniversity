using Official.Application.Contracts.Command.Security;
using Official.Application.Contracts.Command.Security.Role;
using Official.Domain.Model.Security.IRoleRepository;
using Official.Framework.Application;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Official.Application.Command.Security
{
    public class RoleCommandHandlers : ICommandHandler<CreateRoleCommand, long>, ICommandHandler<UpdateRoleCommand, long>, ICommandHandler<RemoveRoleCommand, int>
    {
        private readonly IRoleRepository _roleRepository;
        public RoleCommandHandlers(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<long> HandleAsync(CreateRoleCommand command)
        {
            try
            {
                _roleRepository.BeginTransaction();
                if (string.IsNullOrWhiteSpace(command.Name))
                    throw new Exception("لطفا نام گروه را پر کنید");

                var isExistsRole = await _roleRepository.IsExistsRoleAsync(command.Id, command.Name);
                if (isExistsRole)
                    throw new Exception("نام گروه تکراری است");

                var roleId = await _roleRepository.Create(command.Name);

                if (roleId == 0)
                    throw new Exception("خطا در انجام عملیات");

                await _roleRepository.CreateUserRole(roleId, command.UserIds);
                _roleRepository.Commit();
                return roleId;
            }
            catch (Exception e)
            {
                _roleRepository.Rollback();
                throw e;
            }
        }

        public async Task<long> HandleAsync(UpdateRoleCommand command)
        {
            try
            {
                _roleRepository.BeginTransaction();

                if (string.IsNullOrWhiteSpace(command.Name))
                    throw new Exception("لطفا نام گروه را پر کنید");

                var isExistsRole = await _roleRepository.IsExistsRoleAsync(command.Id, command.Name);
                if (isExistsRole)
                    throw new Exception("نام گروه تکراری است");

                var roleId = await _roleRepository.UpdateAsync(command.Id, command.Name);

                if (roleId == 0)
                    throw new Exception("خطا در انجام عملیات");

                await _roleRepository.RemoveUserRole(roleId);

                await _roleRepository.CreateUserRole(roleId, command.UserIds);
                _roleRepository.Commit();
                return roleId;
            }
            catch (Exception e)
            {
                _roleRepository.Rollback();
                throw e;
            }
        }

        public async Task<int> HandleAsync(RemoveRoleCommand command)
        {
            try
            {
                _roleRepository.BeginTransaction();
                var rowsAffected = await _roleRepository.Remove(command.Id);
                if (rowsAffected > 0)
                    await _roleRepository.RemoveUserRole(command.Id);
                _roleRepository.Commit();
                return rowsAffected;
            }
            catch (Exception e)
            {
                _roleRepository.Rollback();
                throw e;
            }
        }
    }
}
