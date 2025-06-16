using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.Animal;
using VeterinaryClinic.BLL.DTOs.AnimalDisease;
using VeterinaryClinic.BLL.DTOs.AnimalMedicalRecord;
using VeterinaryClinic.BLL.DTOs.AnimalType;
using VeterinaryClinic.BLL.DTOs.Employee;
using VeterinaryClinic.BLL.DTOs.EmployeeSpecialty;
using VeterinaryClinic.BLL.DTOs.HospitalDepartment;
using VeterinaryClinic.BLL.DTOs.HospitalRoom;
using VeterinaryClinic.BLL.DTOs.Owner;
using VeterinaryClinic.DAL.Entities;

namespace VeterinaryClinic.BLL.Configuration
{
    public static class MapsterConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<CreateAnimalDto, Animal>.NewConfig();
            TypeAdapterConfig<Animal, AnimalDto>.NewConfig()
                .Map(dest => dest.OwnerId, src => src.OwnerId != null ? src.OwnerId : null)
                .Map(dest => dest.AnimalTypeId, src => src.AnimalType.Id);

            TypeAdapterConfig<AnimalDisease, AnimalDiseaseDto>.NewConfig();
            TypeAdapterConfig<CreateAnimalDiseaseDto, AnimalDisease>.NewConfig();
            TypeAdapterConfig<AnimalDiseaseDto, AnimalDisease>.NewConfig();

            TypeAdapterConfig<AnimalMedicalRecord, AnimalMedicalRecordDto>.NewConfig()
                .Map(dest => dest.AnimalId, src => src.AnimalId)
                .Map(dest => dest.DiseaseId, src => src.DiseaseId != null ? src.DiseaseId : null)
                .Map(dest => dest.EmployeeId, src => src.EmployeeId != null ? src.EmployeeId : null)
                .Map(dest => dest.RoomId, src => src.RoomId != null ? src.RoomId : null);
            TypeAdapterConfig<CreateAnimalMedicalRecordDto, AnimalMedicalRecord>.NewConfig();
            TypeAdapterConfig<AnimalMedicalRecordDto, AnimalMedicalRecord>.NewConfig();

            TypeAdapterConfig<AnimalType, AnimalTypeDto>.NewConfig()
                .Map(dest => dest.AnimalTypeName, src => src.AnimalTypeName);
            TypeAdapterConfig<CreateAnimalTypeDto, AnimalType>.NewConfig();
            TypeAdapterConfig<AnimalTypeDto, AnimalType>.NewConfig();

            TypeAdapterConfig<Employee, EmployeeDto>.NewConfig();
            TypeAdapterConfig<EmployeeDto, Employee>.NewConfig();
            TypeAdapterConfig<CreateEmployeeDto, Employee>.NewConfig();

            TypeAdapterConfig<EmployeeSpecialty, EmployeeSpecialtyDto>.NewConfig();
            TypeAdapterConfig<EmployeeSpecialtyDto, EmployeeSpecialty>.NewConfig();
            TypeAdapterConfig<CreateEmployeeSpecialtyDto, EmployeeSpecialty>.NewConfig();

            TypeAdapterConfig<HospitalDepartment, HospitalDepartmentDto>.NewConfig();
            TypeAdapterConfig<HospitalDepartmentDto, HospitalDepartment>.NewConfig();
            TypeAdapterConfig<CreateHospitalDepartmentDto, HospitalDepartment>.NewConfig();

            TypeAdapterConfig<HospitalRoom, HospitalRoomDto>.NewConfig()
                .Map(dest => dest.DepartmentId, src => src.DepartmentId != null ? src.DepartmentId : null)
                .Map(dest => dest.AnimalTypeId, src => src.AnimalTypeId != null ? src.AnimalTypeId : null)
                .Map(dest => dest.CurrentAnimalId, src => src.CurrentAnimalId != null ? src.CurrentAnimalId : null);
            TypeAdapterConfig<HospitalRoomDto, HospitalRoom>.NewConfig();
            TypeAdapterConfig<CreateHospitalRoomDto, HospitalRoom>.NewConfig();

            TypeAdapterConfig<Owner, OwnerDto>.NewConfig();
            TypeAdapterConfig<OwnerDto, Owner>.NewConfig();
            TypeAdapterConfig<CreateOwnerDto, Owner>.NewConfig();
        }

    }
}
