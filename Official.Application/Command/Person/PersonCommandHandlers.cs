using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mapster;
using Official.Application.Contracts.Command.Person;
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
                const int create = 1;

                var input = command.NationalCode.PadLeft(10, '0');
                if (!Regex.IsMatch(input, @"^\d{10}$"))
                {
                    throw new Exception("کد ملی وارد شده نامعتبر است");
                }

                var person = _personRepository.IsExistsNationalCode(command.Id, command.NationalCode, create);
                if(person != null)
                {
                    throw new Exception("کد ملی تکراری است");
                }

                var entity = Domain.Model.Person.Person.Instance;
                command.Adapt(entity);
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
                const int create = 2;

                var input = command.NationalCode.PadLeft(10, '0');
                if (!Regex.IsMatch(input, @"^\d{10}$"))
                {
                    throw new Exception("کد ملی وارد شده نامعتبر است");
                }

                var person = _personRepository.IsExistsNationalCode(command.Id, command.NationalCode, create);
                if (person != null)
                {
                    throw new Exception("کد ملی تکراری است");
                }

                var entity = await _personRepository.GetById(command.Id);
                entity.Adapt(command);
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
                return DeletePersonCommand.Instance;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
