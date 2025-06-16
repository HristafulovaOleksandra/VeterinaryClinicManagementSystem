using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VeterinaryClinic.DAL.Data;
using VeterinaryClinic.DAL.Repositories.Interfaces;
using VeterinaryClinic.DAL.UOW;

namespace VeterinaryClinic.DAL
{
    public static class Extensions
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<VeterinaryClinicManagmentContext>(options =>
                options.UseNpgsql(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
