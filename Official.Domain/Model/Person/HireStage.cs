using Official.Domain.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Official.Domain.Model.CommonEntity.HireStage
{
    [DisplayAttribute(Name ="حالت استخدامی")]
    public class HireStage : Entity
    {
        [DisplayAttribute(Name ="عنوان وضعیت استخدامی مدرس")]
        public string Name { get; set; }

        [DisplayAttribute(Name = "ترم آموزشی")]
        public long TermId { get; set; }

        [DisplayAttribute(Name = "توضیحات")]
        public string Description { get; set; }

        [DisplayAttribute(Name = "نوع استخدام")]
        public int HireTypeId { get; set; }

        [DisplayAttribute(Name = "نام فرد")]
        public long PersonId { get; set; }


        public Person.Person Person { get; set; }
        public Term.Term Term { get; set; }
    }
}
