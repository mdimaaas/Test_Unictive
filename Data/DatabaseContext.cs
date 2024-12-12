using Microsoft.EntityFrameworkCore;
using UnictiveTest.Models;

namespace UnictiveTest.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<User> tUser { get; set; }
        public DbSet<Hobby> tHobby { get; set; }
        public DbSet<UserHobby> tUserHobby { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserHobby>()
                .ToTable("tUserHobby")
                .HasKey(uh => uh.fID);

            modelBuilder.Entity<UserHobby>()
                .HasOne(uh => uh.User)
                .WithMany(u => u.UserHobbies)
                .HasForeignKey(uh => uh.fUserID);

            modelBuilder.Entity<UserHobby>()
                .HasOne(uh => uh.Hobby)
                .WithMany(h => h.UserHobbies)
                .HasForeignKey(uh => uh.fHobbyID);

            base.OnModelCreating(modelBuilder);
        }
    }
}
