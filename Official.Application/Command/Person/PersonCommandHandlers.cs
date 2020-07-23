using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                var entities = ConvertExcelToList(command.fileData);

                var updatePerson = _personRepository.GetExistsPerson(entities);
                var newPersons = entities.Where(a => updatePerson.Any(b => b.NationalCode != a.NationalCode)).ToList();

                //map exists Person
                updatePerson.ForEach(person =>
                {
                    var source = entities.Where(b => b.NationalCode == person.NationalCode).FirstOrDefault();
                    person = source.Adapt(person);
                    person.BirthCertificate = source.BirthCertificate.Adapt(person.BirthCertificate);
                    person.Contact = source.Contact.Adapt(person.Contact);
                    person.PersonDetail = source.PersonDetail.Adapt(person.PersonDetail);
                });

                await _personRepository.UpdateRangeAsync(updatePerson);
                await _personRepository.CreateRangeAsync(newPersons);

                return true;
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
                var personList = new List<Domain.Model.Person.Person>();
                using (var memory = new MemoryStream(fileData))
                {
                    using (var excel = new OfficeOpenXml.ExcelPackage(memory))
                    {
                        Regex regex = new Regex(@"^\d*\.?\d*$");
                        var workbook = excel.Workbook;
                        var firstSheet = excel.Workbook.Worksheets[1];
                        if (firstSheet == null) throw new Exception("فایل اکسل ارسالی خالی می باشد");
                        for (int i = firstSheet.Dimension.Start.Row + 1; i <= firstSheet.Dimension.End.Row; i++)
                        {
                            var personDto = new CreatePersonCommand()
                            {
                                NationalCode = (firstSheet.GetValue(i, 1) ?? string.Empty).ToString(),
                                PersonnelCode = (firstSheet.GetValue(i, 2) ?? string.Empty).ToString(),
                                TeacherCode = (firstSheet.GetValue(i, 3) ?? string.Empty).ToString(),
                                FirstName = (firstSheet.GetValue(i, 4) ?? string.Empty).ToString(),
                                LastName = (firstSheet.GetValue(i, 5) ?? string.Empty).ToString(),
                                PositionId = regex.IsMatch((firstSheet.GetValue(i, 6) ?? throw new Exception("مقدار سمت غیرمجاز می باشد")).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 6)) : throw new Exception("مقدار سمت غیرمجاز می باشد"),
                                IsConvert = true,

                                EFirstName = (firstSheet.GetValue(i, 7) ?? string.Empty).ToString(),
                                ELastName = (firstSheet.GetValue(i, 8) ?? string.Empty).ToString(),
                                FatherName = (firstSheet.GetValue(i, 9) ?? string.Empty).ToString(),
                                No = (firstSheet.GetValue(i, 10) ?? string.Empty).ToString(),
                                IssueCityId = regex.IsMatch((firstSheet.GetValue(i, 12) ?? 0).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 11).ToString()) : 0,
                                BirthCountryId = regex.IsMatch((firstSheet.GetValue(i, 12) ?? 0).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 12)) : 0,
                                BirthProvinceId = regex.IsMatch((firstSheet.GetValue(i, 13) ?? 0).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 13)) : 0,
                                BirthCityId = regex.IsMatch((firstSheet.GetValue(i, 14) ?? 0).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 14)) : 0,
                                BirthDate = (firstSheet.GetValue(i, 15) ?? string.Empty).ToString(),
                                GenderId = regex.IsMatch((firstSheet.GetValue(i, 16) ?? 0).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 16)) : 0,
                                PrefixId = regex.IsMatch((firstSheet.GetValue(i, 17) ?? 0).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 17)) : 0,
                                MarriedId = regex.IsMatch((firstSheet.GetValue(i, 18) ?? 0).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 18)) : 0,
                                
                                Address = (firstSheet.GetValue(i, 19) ?? string.Empty).ToString(),
                                Description = (firstSheet.GetValue(i, 20) ?? string.Empty).ToString(),
                                Email = (firstSheet.GetValue(i, 21) ?? string.Empty).ToString(),
                                Mobile = (firstSheet.GetValue(i, 22) ?? string.Empty).ToString(),
                                NecessaryContactNumber = (firstSheet.GetValue(i, 23) ?? string.Empty).ToString(),
                                PostalCode = (firstSheet.GetValue(i, 24) ?? string.Empty).ToString(),
                                PostBox = (firstSheet.GetValue(i, 25) ?? string.Empty).ToString(),
                                WorkAddress = (firstSheet.GetValue(i, 26) ?? string.Empty).ToString(),
                                WorkplacePhoneNumber = (firstSheet.GetValue(i, 27) ?? string.Empty).ToString(),

                                EnlistCode = (firstSheet.GetValue(i, 28) ?? string.Empty).ToString(),
                                EnlistId = regex.IsMatch((firstSheet.GetValue(i, 29) ?? 0).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 29)) : 0,
                                EthnicityId = regex.IsMatch((firstSheet.GetValue(i, 30) ?? 0).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 30)) : 0,
                                IndigenousSituationId = regex.IsMatch((firstSheet.GetValue(i, 31) ?? 0).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 31)) : 0,
                                NationalityId = regex.IsMatch((firstSheet.GetValue(i, 32) ?? 0).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 32)) : 0,
                                ReligionId = regex.IsMatch((firstSheet.GetValue(i, 33) ?? 0).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 33)) : 0,
                                SubReligionId = regex.IsMatch((firstSheet.GetValue(i, 34) ?? 0).ToString()) ? Convert.ToInt32(firstSheet.GetValue(i, 34).ToString()) : 0
                            };

                            var entity = new Domain.Model.Person.Person();
                            entity = personDto.Adapt(entity);
                            entity.BirthCertificate = personDto.Adapt(entity.BirthCertificate);
                            entity.Contact = personDto.Adapt(entity.Contact);
                            entity.PersonDetail = personDto.Adapt(entity.PersonDetail);

                            personList.Add(entity);
                        }
                    }
                }
                return personList;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
