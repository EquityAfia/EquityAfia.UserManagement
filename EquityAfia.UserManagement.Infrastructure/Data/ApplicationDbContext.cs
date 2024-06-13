using Microsoft.EntityFrameworkCore;
using EquityAfia.UserManagement.Domain.UserAggregate;
using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;

namespace EquityAfia.UserManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Practitioner> Practitioners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<User>("User")
                .HasValue<Practitioner>("Practitioner");
        }
    }
}
