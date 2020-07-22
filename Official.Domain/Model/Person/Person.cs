using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Official.Domain.Model.Common;

namespace Official.Domain.Model.Person
{
    [DisplayAttribute(Name ="اطلاعات فردی")]
    public sealed class Person : AggregateRoot
    {
        [DisplayAttribute(Name ="کد مدرس")]
        public string TeacherCode { get; private set; }

        [DisplayAttribute(Name ="کد ملی")]
        public string NationalCode { get; private set; }

        [DisplayAttribute(Name ="کد پرسنلی")]
        public string PersonnelCode { get; private set; }

        [DisplayAttribute(Name ="نام")]
        public string FirstName { get; private set; }

        [DisplayAttribute(Name ="نام خانوادگی")]
        public string LastName { get; private set; }

        [DisplayAttribute(Name = "سمت شغلی")]
        public int PositionId { get; set; }

        [DisplayAttribute(Name = "ارسالی از اکسل")]
        public bool? IsConvert { get; set; }

        public BirthCertificate BirthCertificate { get; set; }
        public PersonDetail PersonDetail { get; set; }
        public Contact Contact { get; set; }
        public IList<EducationalInfo> EducationalInfos { get; private set; }
        public IList<HistoryEducational> HistoryEducationals { get; private set; }
        public IList<HireStage> HireStages { get; set; }

        //private Person()
        //{
        //}
        //private static Person instance = null;
        //public static Person Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new Person();
        //        }
        //        return instance;
        //    }
        //}

        public bool IsValidNationalCode(string value)
        {
            try
            {
                string input = value as string;
                // input has 10 digits that all of them are not equal
                if (!System.Text.RegularExpressions.Regex.IsMatch(input, @"^(?!(\d)\1{9})\d{10}$"))
                    return false;

                var check = Convert.ToInt32(input.Substring(9, 1));
                var sum = Enumerable.Range(0, 9)
                              .Select(x => Convert.ToInt32(input.Substring(x, 1)) * (10 - x))
                              .Sum() % 11;

                return sum < 2 && check == sum || sum >= 2 && check + sum == 11;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
