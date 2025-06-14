using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.DAL.Data; 
using Microsoft.Extensions.Logging;
using VeterinaryClinic.DAL.Repositories.Interfaces;
using VeterinaryClinic.DAL.UOW;

namespace VeterinaryClinic.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //Connection for EF database
            builder.Services.AddDbContext<VeterinaryClinicManagmentContext>(options =>
                options.UseNpgsql(connectionString));
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<VeterinaryClinicManagmentContext>();
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating or seeding the database.");
                }
            }
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
