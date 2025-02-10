using Backend.Api.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<BdContext>(op => op.UseNpgsql(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
Console.WriteLine(connectionString);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
TestarConexaoBancoDeDados(app); // Chama o método de teste

app.Run();

// Método de teste
static void TestarConexaoBancoDeDados(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<BdContext>();

        if (context.TestarConexao()) // Chama o método TestarConexao do seu contexto
        {
            Console.WriteLine("Conexão com o banco de dados bem-sucedida!");
        }
        else
        {
            Console.WriteLine("Falha na conexão com o banco de dados.");
        }
    }
}

// "ConnectionStrings": {
//   "default": "postgres://postgres:Lar@123@db:5432/lardb?schema=public"
// }