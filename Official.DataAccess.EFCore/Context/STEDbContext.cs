using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Official.Domain.Model.CommonEntity;
using Official.Domain.Model.CommonEntity.Enum;
using Official.Domain.Model.CommonEntity.Menu;
using Official.Domain.Model.CommonEntity.Term;
using Official.Domain.Model.Person;
using Official.Persistence.EFCore.Identity;
using Official.Persistence.EFCore.Mappings;

namespace Official.Persistence.EFCore.Context
{
    public class STEDbContext : IdentityDbContext<AppUser, AppRole, long, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public STEDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new LetterMapping());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Term> Terms { get; set; }
        public DbSet<HireStage> HireStages { get; set; }

        public DbSet<Person> Persons { get; set; }
        public DbSet<BirthCertificate> BirthCertificates { get; set; }
        public DbSet<PersonDetail> PersonDetails { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        public DbSet<EducationalInfo> EducationalInfos { get; set; }
        public DbSet<HistoryEducational> HistoryEducationals { get; set; }
        public DbSet<DegreeAttach> DegreeAttaches { get; set; }

        public DbSet<Menu> Menus { get; set; }

        public DbSet<Place> Places { get; set; }

        public DbSet<Enumuration> Enumurations { get; set; }
    }
}
