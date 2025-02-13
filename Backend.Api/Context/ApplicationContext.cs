

using Backend.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Context
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {

        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<User> Users { get; set; }

    }
}