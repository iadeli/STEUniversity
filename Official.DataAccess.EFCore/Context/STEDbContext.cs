using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Official.Domain.Model.Enum;
using Official.Domain.Model.Menu;
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

        public DbSet<Enumuration> Enumurations { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}
