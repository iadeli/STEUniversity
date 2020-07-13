using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Official.Domain.Model.Audit;
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
            _user = new UserResolverService(new HttpContextAccessor())?.GetUser(); // userService?.GetUser();
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
            AuditManager.DefaultConfiguration.AuditEntryPropertyFactory = arg => new CustomAuditEntryProperty()
            {
                EnPropertyName = arg.PropertyName
            };

            AuditManager.DefaultConfiguration
                    .Format<EducationalInfo>(x => x.TermId, x => Resourse.ResourceQuery.ResourceManager.GetString("TermId") + $"'{x}'");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new LetterMapping());
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
        public DbSet<CustomAuditEntryProperty> AuditEntryProperties { get; set; }

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
