using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.DAL.Data;
using VeterinaryClinic.DAL.Repositories.Interfaces;
using VeterinaryClinic.DAL.Repositories;

namespace VeterinaryClinic.DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VeterinaryClinicManagmentContext _context;

        public IAnimalTypeRepository AnimalTypes { get; private set; }
        public IOwnerRepository Owners { get; private set; }
        public IAnimalRepository Animals { get; private set; }
        public IAnimalDiseaseRepository AnimalDiseases { get; private set; }
        public IHospitalDepartmentRepository HospitalDepartments { get; private set; }
        public IEmployeeSpecialtyRepository EmployeeSpecialties { get; private set; }
        public IEmployeeRepository Employees { get; private set; }
        public IHospitalRoomRepository HospitalRooms { get; private set; }
        public IAnimalMedicalRecordRepository AnimalMedicalRecords { get; private set; }

        public UnitOfWork(VeterinaryClinicManagmentContext context)
        {
            _context = context;

            AnimalTypes = new AnimalTypeRepository(_context);
            Owners = new OwnerRepository(_context);
            Animals = new AnimalRepository(_context);
            AnimalDiseases = new AnimalDiseaseRepository(_context);
            HospitalDepartments = new HospitalDepartmentRepository(_context);
            EmployeeSpecialties = new EmployeeSpecialtyRepository(_context);
            Employees = new EmployeeRepository(_context);
            HospitalRooms = new HospitalRoomRepository(_context);
            AnimalMedicalRecords = new AnimalMedicalRecordRepository(_context);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
