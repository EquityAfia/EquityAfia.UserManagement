using EquityAfia.UserManagement.Domain.UserAggregate.UsersEntities;
using EquityAfia.UserManagement.Domain.RolesAggregate.RolesEntity;
using Microsoft.EntityFrameworkCore;

namespace EquityAfia.UserManagement.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Practitioner> Practitioners { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<PractitionerType> PractitionerTypes { get; set; }
        public DbSet<UserType> UserTypes { get; set; } // Rename to Types to avoid collision and confusion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<User>("User")
                .HasValue<Practitioner>("Practitioner");

            modelBuilder.Entity<UserRole>()
                .HasKey(ur => ur.Id);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.Id); 

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<PractitionerType>()
                .HasOne(pt => pt.Practitioner)
                .WithMany(p => p.PractitionerTypes) 
                .HasForeignKey(pt => pt.PractitionerId);

            modelBuilder.Entity<PractitionerType>()
                .HasOne(pt => pt.Type)
                .WithMany(t => t.PractitionerTypes)
                .HasForeignKey(pt => pt.TypeId);
        }
    }
}
