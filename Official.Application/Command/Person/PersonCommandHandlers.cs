using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mapster;
using Official.Application.Contracts.Command.Person;
using Official.Application.Contracts.Command.Person.PersonCommand;
using Official.Domain.Model.Person.IPersonRepository;
using Official.Framework.Application;

namespace Official.Application.Command.Person
{
    public class PersonCommandHandlers : ICommandHandler<CreatePersonCommand>, ICommandHandler<UpdatePersonCommand>, ICommandHandler<DeletePersonCommand>
    {
        private readonly IPersonRepository _personRepository;
        public PersonCommandHandlers(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<CreatePersonCommand> Handle(CreatePersonCommand command)
        {
            try
            {
                var entity = new Domain.Model.Person.Person(); //Domain.Model.Person.Person.Instance;
                entity = command.Adapt(entity);

                if(!entity.IsValidNationalCode(entity.NationalCode))
                    throw new Exception("کد ملی وارد شده نامعتبر است");

                const int create = 1;
                var isExistsTeacherCode = await _personRepository.IsExistsTeacherCodeAsync(entity, create);
                if (isExistsTeacherCode)
                    throw new Exception("کد مدرس تکراری است");

                var isExistsNationalCode = await _personRepository.IsExistsNationalCodeAsync(entity, create);
                if (isExistsNationalCode)
                    throw new Exception("کد ملی تکراری است");

                var isExistsPersonalCode = await _personRepository.IsExistsPersonalCodeAsync(entity, create);
                if (isExistsPersonalCode)
                    throw new Exception("کد پرسنلی تکراری است");

                entity.BirthCertificate = command.Adapt(entity.BirthCertificate);
                entity.PersonDetail = command.Adapt(entity.PersonDetail);
                entity.Contact = command.Adapt(entity.Contact);

                entity = await _personRepository.Create(entity);
                var dto = entity.Adapt(command);
                return dto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<UpdatePersonCommand> Handle(UpdatePersonCommand command)
        {
            try
            {
                var entity = await _personRepository.GetById(command.Id);
                entity = command.Adapt(entity);

                if (!entity.IsValidNationalCode(entity.NationalCode))
                    throw new Exception("کد ملی وارد شده نامعتبر است");

                const int update = 2;
                var isExistsTeacherCode = await _personRepository.IsExistsTeacherCodeAsync(entity, update);
                if (isExistsTeacherCode)
                    throw new Exception("کد مدرس تکراری است");

                var isExistsNationalCode = await _personRepository.IsExistsNationalCodeAsync(entity, update);
                if (isExistsNationalCode)
                    throw new Exception("کد ملی تکراری است");

                var isExistsPersonalCode = await _personRepository.IsExistsPersonalCodeAsync(entity, update);
                if (isExistsPersonalCode)
                    throw new Exception("کد پرسنلی تکراری است");

                entity.BirthCertificate = command.Adapt(entity.BirthCertificate);
                entity.PersonDetail = command.Adapt(entity.PersonDetail);
                entity.Contact = command.Adapt(entity.Contact);

                entity = await _personRepository.Update(entity);
                var dto = entity.Adapt(command);
                return dto;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<DeletePersonCommand> Handle(DeletePersonCommand command)
        {
            try
            {
                await _personRepository.Remove(command.Id);
                return new DeletePersonCommand(); //DeletePersonCommand.Instance;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
