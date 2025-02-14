using System.Text;
using Backend.Api.Context;
using Backend.Api.Filters;
using Backend.Api.Repositories;
using Backend.Api.Repositories.Interfaces;
using Backend.Api.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{

    // Configura o Swagger para usar autenticação JWT
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insira o token JWT no campo abaixo:",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },

            new string[] {}
        }
    });
});
string connectionString = builder.Configuration.GetConnectionString("default");
builder.Services.AddDbContext<ApplicationContext>(op => op.UseNpgsql(connectionString));
//Add repositories and services:
builder.Services.AddScoped<PersonRepository>();
builder.Services.AddScoped<PersonService>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));


builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecurityKey"]))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Services.CreateScope().ServiceProvider.GetRequiredService<ApplicationContext>().Database.Migrate();
}
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();



// "ConnectionStrings": {
//   "default": "postgres://postgres:Lar@123@db:5432/lardb?schema=public"
// }