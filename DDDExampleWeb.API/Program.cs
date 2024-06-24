
using DDDExampleWeb.Application.Interfaces;
using DDDExampleWeb.Application.Services;
using DDDExampleWeb.Domain.Interfaces;
using DDDExampleWeb.Infrastructure.Datas;
using DDDExampleWeb.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DDDExampleWeb.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<ExampleDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

            builder.Services.AddScoped<IExampleRepository, ExampleRepository>();
            builder.Services.AddScoped<IExampleService, ExampleService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
