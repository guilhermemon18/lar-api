

using Backend.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Api.Context
{
    public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
    {
        public bool TestarConexao()
        {
            try
            {
                return Database.CanConnect();
            }
            catch (Exception ex)
            {
                // Log do erro (opcional)
                Console.WriteLine($"Erro ao conectar ao banco de dados: {ex.Message}");
                return false;
            }
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Phone> Phones { get; set; }

    }
}