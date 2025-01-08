using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text.Json.Serialization;

namespace Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();

            var connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connString));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //converting my enum description to become visible to my client
            builder.Services.AddControllers()
               .AddJsonOptions(options =>
               {
                   options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
               });
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
