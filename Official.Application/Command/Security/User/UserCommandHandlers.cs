using Mapster;
using Official.Application.Contracts.Command.Security.User;
using Official.Application.Contracts.Command.User;
using Official.Domain.Model.Security;
using Official.Domain.Model.Security.IUserRepository;
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

        public async Task<long> HandleAsync(CreateUserCommand command)
        {
            try
            {
                _userRepository.BeginTransaction();

                if (string.IsNullOrWhiteSpace(command.UserName))
                    throw new Exception("لطفا نام کاربری را پر کنید");
                if (string.IsNullOrWhiteSpace(command.Password))
                    throw new Exception("لطفا کلمه عبور را پر کنید");
                if (command.PersonId == 0)
                    throw new Exception("لطفا نام پرسنل را انتخاب کنید");

                var appUserTransfer = new AppUserTransfer();
                appUserTransfer = command.Adapt(appUserTransfer);

                var isExistsUserName = _userRepository.IsExistsUserName(appUserTransfer);
                if (isExistsUserName)
                    throw new Exception("این نام کاربری قبلا استفاده شده است");

                var isExistsPerson = _userRepository.IsExistsPerson(appUserTransfer);
                if (isExistsPerson)
                    throw new Exception("این فرد دارای اکانت کاربری می باشد");

                var succeeded = await _userRepository.Create(appUserTransfer);
                if (!succeeded)
                    throw new Exception("خطا در انجام عملیات");

                var userId = await _userRepository.GetUserIdByUserName(command.UserName);

                var rowsAffected = await _userRepository.CreateUserRole(userId, command.RoleIds);

                _userRepository.Commit();
                _userRepository.Dispose();

                return userId;
            }
            catch (Exception e)
            {
                _userRepository.Rollback();
                _userRepository.Dispose();
                throw e;
            }
        }

        public async Task<long> HandleAsync(UpdateUserCommand command)
        {
            try
            {
                _userRepository.BeginTransaction();

                if (string.IsNullOrWhiteSpace(command.UserName))
                    throw new Exception("لطفا نام کاربری را پر کنید");
                if (string.IsNullOrWhiteSpace(command.Password))
                    throw new Exception("لطفا کلمه عبور را پر کنید");

                var appUserTransfer = _userRepository.GetUserById(command.Id);
                appUserTransfer = command.Adapt(appUserTransfer);

                var isExistsUserName = _userRepository.IsExistsUserName(appUserTransfer);
                if (isExistsUserName)
                    throw new Exception("این نام کاربری قبلا استفاده شده است");

                var isExistsPerson = _userRepository.IsExistsPerson(appUserTransfer);
                if (isExistsPerson)
                    throw new Exception("این فرد دارای اکانت کاربری می باشد");

                var userId = await _userRepository.Update(appUserTransfer);
                await _userRepository.RemoveUserRole(userId);
                await _userRepository.UpdateUserRoleAsync(userId, appUserTransfer.RoleIds);

                _userRepository.Commit();
                _userRepository.Dispose();

                return userId;
            }
            catch (Exception e)
            {
                _userRepository.Rollback();
                _userRepository.Dispose();
                throw e;
            }
        }

        public async Task<int> HandleAsync(RemoveUserCommand command)
        {
            try
            {
                _userRepository.BeginTransaction();
                var rowsAffected = await _userRepository.Remove(command.Id);
                if (rowsAffected > 0)
                    await _userRepository.RemoveUserRole(command.Id);
                _userRepository.Commit();
                _userRepository.Dispose();
                return rowsAffected;
            }
            catch (Exception e)
            {
                _userRepository.Rollback();
                _userRepository.Dispose();
                throw e;
            }
        }
    }
}
