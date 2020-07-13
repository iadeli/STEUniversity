using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Official.Domain.Model.CommonEntity;
using Official.Domain.Model.CommonEntity.Enum;
using Official.Domain.Model.CommonEntity.HireStage;
using Official.Domain.Model.CommonEntity.Menu;
using Official.Domain.Model.CommonEntity.Term;
using Official.Domain.Model.Person;
using Official.Persistence.EFCore.Identity;
using Official.Persistence.EFCore.Mappings;
using Official.Persistence.EFCore.Utility;
using Z.EntityFramework.Plus;

namespace Official.Persistence.EFCore.Context
{
    public class STEDbContext : IdentityDbContext<AppUser, AppRole, long, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        private readonly string _user;
        public STEDbContext(DbContextOptions options) : base(options)
        {
            _user = new UserResolverService(new HttpContextAccessor())?.GetUser(); 
            ManageAuditConfig();
        }

        private void ManageAuditConfig()
        {
            AuditManager.DefaultConfiguration.AutoSavePreAction = (context, audit) =>
                // ADD "Where(x => x.AuditEntryID == 0)" to allow multiple SaveChanges with same Audit
                (context as STEDbContext)?.AuditEntries.AddRange(audit.Entries);
            AuditManager.DefaultConfiguration.ExcludeDataAnnotation();
            AuditManager.DefaultConfiguration.DataAnnotationDisplayName();

            AuditManager.DefaultConfiguration.AuditEntryFactory = arg => new AuditEntry()
            {
                EntitySetName = Resourse.ResourceEntity.ResourceManager.GetString(arg.EntityEntry.Entity.GetType().Name)
            };
            AuditManager.DefaultConfiguration.AuditEntryPropertyFactory = arg => new AuditEntryProperty()
            {
                RelationName = arg.EntityEntry.Entity.GetType().GetProperties().Where(a => a.Name == arg.PropertyName).Select(property => ((DisplayAttribute)property.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault())?.Name).FirstOrDefault()
            };

            AuditManager.DefaultConfiguration.Format<Menu>(x => x.MenuId, x => Resourse.ResourceQuery.ResourceManager.GetString("MenuId") + x);
            AuditManager.DefaultConfiguration.Format<Place>(x => x.PlaceId, x => Resourse.ResourceQuery.ResourceManager.GetString("PlaceId") + x);
            AuditManager.DefaultConfiguration.Format<BirthCertificate>(x => x.GenderId, x => Resourse.ResourceQuery.ResourceManager.GetString("GenderId") + x);
            AuditManager.DefaultConfiguration.Format<BirthCertificate>(x => x.IssueCityId, x => Resourse.ResourceQuery.ResourceManager.GetString("IssueCityId") + x);
            AuditManager.DefaultConfiguration.Format<BirthCertificate>(x => x.BirthCountryId, x => Resourse.ResourceQuery.ResourceManager.GetString("BirthCountryId") + x);
            AuditManager.DefaultConfiguration.Format<BirthCertificate>(x => x.BirthProvinceId, x => Resourse.ResourceQuery.ResourceManager.GetString("BirthProvinceId") + x);
            AuditManager.DefaultConfiguration.Format<BirthCertificate>(x => x.BirthCityId, x => Resourse.ResourceQuery.ResourceManager.GetString("BirthCityId") + x);
            AuditManager.DefaultConfiguration.Format<BirthCertificate>(x => x.PrefixId, x => Resourse.ResourceQuery.ResourceManager.GetString("PrefixId") + x);
            AuditManager.DefaultConfiguration.Format<BirthCertificate>(x => x.MarriedId, x => Resourse.ResourceQuery.ResourceManager.GetString("MarriedId") + x);
            AuditManager.DefaultConfiguration.Format<BirthCertificate>(x => x.PersonId, x => Resourse.ResourceQuery.ResourceManager.GetString("PersonId") + x);
            AuditManager.DefaultConfiguration.Format<Contact>(x => x.PersonId, x => Resourse.ResourceQuery.ResourceManager.GetString("PersonId") + x);
            AuditManager.DefaultConfiguration.Format<DegreeAttach>(x => x.HistoryEducationalId, x => Resourse.ResourceQuery.ResourceManager.GetString("HistoryEducationalId") + $"{x})");
            AuditManager.DefaultConfiguration.Format<EducationalInfo>(x => x.TeacherTypeId, x => Resourse.ResourceQuery.ResourceManager.GetString("TeacherTypeId") + x);
            AuditManager.DefaultConfiguration.Format<EducationalInfo>(x => x.TermId, x => Resourse.ResourceQuery.ResourceManager.GetString("TermId") + x);
            AuditManager.DefaultConfiguration.Format<EducationalInfo>(x => x.PersonId, x => Resourse.ResourceQuery.ResourceManager.GetString("PersonId") + x);
            AuditManager.DefaultConfiguration.Format<HistoryEducational>(x => x.UniversityId, x => Resourse.ResourceQuery.ResourceManager.GetString("UniversityId") + x);
            AuditManager.DefaultConfiguration.Format<HistoryEducational>(x => x.GradeId, x => Resourse.ResourceQuery.ResourceManager.GetString("GradeId") + x);
            AuditManager.DefaultConfiguration.Format<HistoryEducational>(x => x.MajorSubjectId, x => Resourse.ResourceQuery.ResourceManager.GetString("MajorSubjectId") + x);
            AuditManager.DefaultConfiguration.Format<HistoryEducational>(x => x.DegreeId, x => Resourse.ResourceQuery.ResourceManager.GetString("DegreeId") + x);
            AuditManager.DefaultConfiguration.Format<HistoryEducational>(x => x.PersonId, x => Resourse.ResourceQuery.ResourceManager.GetString("PersonId") + x);
            AuditManager.DefaultConfiguration.Format<PersonDetail>(x => x.EnlistId, x => Resourse.ResourceQuery.ResourceManager.GetString("EnlistId") + x);
            AuditManager.DefaultConfiguration.Format<PersonDetail>(x => x.ReligionId, x => Resourse.ResourceQuery.ResourceManager.GetString("ReligionId") + x);
            AuditManager.DefaultConfiguration.Format<PersonDetail>(x => x.SubReligionId, x => Resourse.ResourceQuery.ResourceManager.GetString("SubReligionId") + x);
            AuditManager.DefaultConfiguration.Format<PersonDetail>(x => x.NationalityId, x => Resourse.ResourceQuery.ResourceManager.GetString("NationalityId") + x);
            AuditManager.DefaultConfiguration.Format<PersonDetail>(x => x.EthnicityId, x => Resourse.ResourceQuery.ResourceManager.GetString("EthnicityId") + x);
            AuditManager.DefaultConfiguration.Format<PersonDetail>(x => x.IndigenousSituationId, x => Resourse.ResourceQuery.ResourceManager.GetString("IndigenousSituationId") + x);
            AuditManager.DefaultConfiguration.Format<PersonDetail>(x => x.PersonId, x => Resourse.ResourceQuery.ResourceManager.GetString("PersonId") + x);
            AuditManager.DefaultConfiguration.Format<AppUser>(x => x.PersonId, x => Resourse.ResourceQuery.ResourceManager.GetString("PersonId") + x);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonMapping).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            var rowAffecteds = 0;
            var audit = new Audit();
            audit.CreatedBy = _user;
            audit.PreSaveChanges(this);
            rowAffecteds = base.SaveChanges();
            audit.PostSaveChanges();
            if (audit.Configuration.AutoSavePreAction != null)
            {
                audit.Configuration.AutoSavePreAction(this, audit);
                base.SaveChanges();
            }
            return rowAffecteds;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var rowAffecteds = 0;
            //using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            //{
            var audit = new Audit();
            audit.CreatedBy = _user;
            audit.PreSaveChanges(this);
            rowAffecteds = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            audit.PostSaveChanges();
            if (audit.Configuration.AutoSavePreAction != null)
            {
                audit.Configuration.AutoSavePreAction(this, audit);
                await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
            }
            //scope.Complete();
            //}
            return rowAffecteds;
        }
        
        public DbSet<AuditEntry> AuditEntries { get; set; }
        public DbSet<AuditEntryProperty> AuditEntryProperties { get; set; }
        public DbSet<AppUser> AspNetUsers { get; set; }
        public DbSet<AppRole> AspNetRoles { get; set; }
        public DbSet<AppUserRole> AspNetUserRoles { get; set; }
        public DbSet<AppUserClaim> AspNetUserClaims { get; set; }
        public DbSet<AppRoleClaim> AspNetRoleClaims { get; set; }
        public DbSet<AppUserLogin> AspNetUserLogins { get; set; }
        public DbSet<AppUserToken> AspNetUserTokens { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Enumuration> Enumurations { get; set; }
        public DbSet<Term> Terms { get; set; }
        public DbSet<HireStage> HireStages { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<BirthCertificate> BirthCertificates { get; set; }
        public DbSet<PersonDetail> PersonDetails { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<EducationalInfo> EducationalInfos { get; set; }
        public DbSet<HistoryEducational> HistoryEducationals { get; set; }
        public DbSet<DegreeAttach> DegreeAttaches { get; set; }
    }
}
