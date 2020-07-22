using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Mapster;
using Official.Application.Contracts.Command.Person;
using Official.Application.Contracts.Command.Person.Excell;
using Official.Application.Contracts.Command.Person.PersonCommand;
using Official.Domain.Model.Person.IPersonRepository;
using Official.Framework.Application;

namespace Official.Application.Command.Person
{
    public class PersonCommandHandlers : ICommandHandler<CreatePersonCommand, long>, ICommandHandler<UpdatePersonCommand, 
        long>, ICommandHandler<DeletePersonCommand, int>, ICommandHandler<CreatePersonExcelCommand, bool>
    {
        private readonly IPersonRepository _personRepository;
        public PersonCommandHandlers(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task<long> HandleAsync(CreatePersonCommand command)
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
                return entity.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<long> HandleAsync(UpdatePersonCommand command)
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
                return entity.Id;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> HandleAsync(DeletePersonCommand command)
        {
            try
            {
                return await _personRepository.Remove(command.Id);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<bool> HandleAsync(CreatePersonExcelCommand command)
        {
            try
            {
                //TODO: ذخیره جزئیات فایل ارسالی

                var personDto = ConvertExcelToList(command.fileData);

            }
            catch (Exception e)
            {
                throw;
            }
        }

        private List<Domain.Model.Person.Person> ConvertExcelToList(byte[] fileData)
        {
            try
            {
                var personDtoList = new List<PersonDto>();
                using (var memory = new MemoryStream(fileData))
                {
                    using (var excel = new OfficeOpenXml.ExcelPackage(memory))
                    {
                        var workbook = excel.Workbook;
                        var firstSheet = excel.Workbook.Worksheets[1];
                        if (firstSheet == null) throw new Exception("فایل اکسل ارسالی خالی می باشد");
                        for (int i = firstSheet.Dimension.Start.Row + 1; i <= firstSheet.Dimension.End.Row; i++)
                        {
                            var person = new CreatePersonCommand()
                            {
                                NationalCode = firstSheet.GetValue(i, 1).ToString(),
                                PersonnelCode = firstSheet.GetValue(i, 2).ToString(),
                                TeacherCode = firstSheet.GetValue(i, 3).ToString(),
                                FirstName = firstSheet.GetValue(i, 4).ToString(),
                                LastName = firstSheet.GetValue(i, 5).ToString(),
                                PositionId = Convert.ToInt32(firstSheet.GetValue(i, 6)),
                                IsConvert = true
                            };
                            var birthCertificateDto = new BirthCertificateDto()
                            {
                                EFirstName = firstSheet.GetValue(i, 7).ToString(),
                                ELastName = firstSheet.GetValue(i, 8).ToString(),
                                FatherName = firstSheet.GetValue(i, 9).ToString(),
                                No = firstSheet.GetValue(i, 10).ToString(),
                                IssueCityId = Convert.ToInt32(firstSheet.GetValue(i, 11).ToString()),
                                BirthCountryId = Convert.ToInt32(firstSheet.GetValue(i, 12)),
                                BirthProvinceId = Convert.ToInt32(firstSheet.GetValue(i, 13)),
                                BirthCityId = Convert.ToInt32(firstSheet.GetValue(i, 14)),

                            }
                            personDtoList.Add(person);
                        }
                        return personDtoList;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
