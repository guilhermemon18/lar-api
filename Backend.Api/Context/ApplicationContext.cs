

using Backend.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Context
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {

        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adiciona um usuário admin
            var adminUser = new User
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@exemplo.com",
                IsAdmin = true,
                Password = "admin123"// criptografar com PasswordHasher em produção, não utilizar texto direto!
            };

            modelBuilder.Entity<User>().HasData(adminUser);

            base.OnModelCreating(modelBuilder);
        }

    }
}