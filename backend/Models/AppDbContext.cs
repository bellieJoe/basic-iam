using backend.Models.Data;
//using DevOne.Security.Cryptography.BCrypt;
using Microsoft.EntityFrameworkCore;


namespace backend.Models
{
    public class AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        private readonly IConfiguration _config = config;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Username)
                .IsUnique();
                
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Role>()
                .HasIndex(r => r.Value)
                .IsUnique();

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Value = "Super Admin",
                    Description = "Super ADmin"
                },
                new Role
                {
                    Id= 2,
                    Value = "Admin",
                    Description = "Admin"
                },
                new Role
                {
                    Id = 3,
                    Value = "Ordinary",
                    Description = "Ordinary User"
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    RoleId = 1,
                    Username = "superadmin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
                    CreatedAt = DateTime.UtcNow,
                    Email = "superadmin@email.com",
                    LastUpdatedAt = DateTime.UtcNow
                },
                new User
                {
                    Id = 2,
                    RoleId = 1,
                    Username = "admin",
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword("password"),
                    CreatedAt = DateTime.UtcNow,
                    Email = "admin@email.com",
                    LastUpdatedAt = DateTime.UtcNow
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
