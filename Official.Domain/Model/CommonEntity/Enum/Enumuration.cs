using Official.Domain.Model.Common;
using System.ComponentModel.DataAnnotations;

namespace Official.Domain.Model.CommonEntity.Enum
{
    [DisplayAttribute(Name ="لیست کمبو")]
    public sealed class Enumuration : Entity
    {
        [DisplayAttribute(Name ="نام فیلد")]
        public string EnumName { get; private set; }

        [DisplayAttribute(Name ="عنوان فیلد")]
        public string EnumTitle { get; private set; }

        [DisplayAttribute(Name ="عنوان لاتین فیلد")]
        public string EnumFiled { get; private set; }

        [DisplayAttribute(Name ="مقدار فیلد")]
        public string EnumValue { get; private set; }
    }
}
