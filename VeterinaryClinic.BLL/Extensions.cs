using Mapster;
using Microsoft.Extensions.DependencyInjection;
using VeterinaryClinic.BLL.Configuration;
using VeterinaryClinic.BLL.Services;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.Helpers;

namespace VeterinaryClinic.BLL
{
    public static class Extensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            MapsterConfig.RegisterMappings();

            services.AddScoped<IAnimalService, AnimalService>();
            services.AddScoped<IAnimalDiseaseService, AnimalDiseaseService>();
            services.AddScoped<IAnimalMedicalRecordService, AnimalMedicalRecordService>();
            services.AddScoped<IAnimalTypeService, AnimalTypeService>();
            services.AddScoped<IHospitalDepartmentService, HospitalDepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeSpecialtyService, EmployeeSpecialtyService>();
            services.AddScoped<IHospitalRoomService, HospitalRoomService>();
            services.AddScoped<IOwnerService, OwnerService>();

            services.AddScoped<ISortHelper<Animal>, SortHelper<Animal>>();
            services.AddScoped<ISortHelper<AnimalMedicalRecord>, SortHelper<AnimalMedicalRecord>>();
            services.AddScoped<ISortHelper<Employee>, SortHelper<Employee>>();
            services.AddScoped<ISortHelper<Owner>, SortHelper<Owner>>();
            services.AddScoped<ISortHelper<HospitalRoom>, SortHelper<HospitalRoom>>();


            return services;
        }
    }
}
