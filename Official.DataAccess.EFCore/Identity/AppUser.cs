using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Z.EntityFramework.Plus;

namespace Official.Persistence.EFCore.Identity
{
    public class AppUser : IdentityUser<long>
    {
        [DisplayAttribute(Name ="نام فرد")]
        public long PersonId { get; set; }

        //private AppUser()
        //{
        //}
        //private static AppUser instance = null;
        //public static AppUser Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new AppUser();
        //        }
        //        return instance;
        //    }
        //}
    }
}
