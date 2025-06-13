using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Address { get; set; }

        public int DepartmentId { get; set; }
        public HospitalDepartment Department { get; set; } = null!;

        public int? SpecialtyId { get; set; }
        public EmployeeSpecialty? Specialty { get; set; }

        public ICollection<AnimalMedicalRecord> MedicalRecords { get; set; } = new List<AnimalMedicalRecord>();
    }

}
