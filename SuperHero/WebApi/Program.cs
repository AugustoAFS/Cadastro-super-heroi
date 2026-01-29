
using ApplicationService.Interfaces;
using ApplicationService.Services;
using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using WebApi.Middlewares;

namespace WebApi    
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<SuperHeroDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IHeroisRepository, HeroisRepository>();
            builder.Services.AddScoped<ISuperpoderesRepository, SuperpoderesRepository>();
            builder.Services.AddScoped<IHeroisSuperpoderesRepository, HeroisSuperpoderesRepository>();

            builder.Services.AddScoped<IHeroiService, HeroiService>();
            builder.Services.AddScoped<ISuperpoderService, SuperpoderService>();

            builder.Services.AddSingleton<ApplicationService.Mappings.HeroiMapper>();
            builder.Services.AddSingleton<ApplicationService.Mappings.SuperpoderMapper>();

            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAngular",
                    builder => builder.WithOrigins("http://localhost:4200")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

            builder.Services.AddOpenApi();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();
            app.MapOpenApi();

            app.UseHttpsRedirection();

            app.UseCors("AllowAngular");

            app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
