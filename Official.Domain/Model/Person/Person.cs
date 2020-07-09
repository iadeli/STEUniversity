using System;
using System.Collections.Generic;
using System.Text;
using Official.Domain.Model.Common;

namespace Official.Domain.Model.Person
{
    public sealed class Person : AggregateRoot
    {
        public string TeacherCode { get; private set; }
        public string PersonnelCode { get; private set; }
        public string NationalCode { get; private set; }

        public BirthCertificate BirthCertificate { get; set; }
        public PersonDetail PersonDetail { get; set; }
        public Contact Contact { get; set; }
        public IList<EducationalInfo> EducationalInfos { get; private set; }
        public IList<HistoryEducational> HistoryEducationals { get; private set; }

        private Person()
        {
        }
        private static Person instance = null;
        public static Person Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Person();
                }
                return instance;
            }
        }
    }
}
