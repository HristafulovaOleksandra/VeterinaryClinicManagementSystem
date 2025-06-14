using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.DAL.Repositories.Interfaces;

namespace VeterinaryClinic.DAL.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        IAnimalTypeRepository AnimalTypes { get; }
        IOwnerRepository Owners { get; }
        IAnimalRepository Animals { get; }
        IAnimalDiseaseRepository AnimalDiseases { get; }
        IHospitalDepartmentRepository HospitalDepartments { get; }
        IEmployeeSpecialtyRepository EmployeeSpecialties { get; }
        IEmployeeRepository Employees { get; }
        IHospitalRoomRepository HospitalRooms { get; }
        IAnimalMedicalRecordRepository AnimalMedicalRecords { get; }

        Task<int> SaveAsync();
    }
}
