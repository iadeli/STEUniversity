using System.ComponentModel.DataAnnotations;
using Official.Domain.Model.Common;

namespace Official.Domain.Model.Person
{
    [Display(Name ="حالت استخدامی")]
    public class HireStage : Entity
    {
        [Display(Name ="عنوان وضعیت استخدامی مدرس")]
        public string Name { get; set; }

        [Display(Name = "ترم آموزشی")]
        public long TermId { get; set; }

        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [Display(Name = "عضو هیئت علمی")]
        public bool IsFacultymember { get; set; }

        [Display(Name = "نام فرد")]
        public long PersonId { get; set; }


        public Model.Person.Person Person { get; set; }
        public CommonEntity.Term.Term Term { get; set; }
    }
}
