using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.DAL.Entities
{
    public class HospitalRoom
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = null!;

        public int? DepartmentId { get; set; }
        public HospitalDepartment? Department { get; set; }

        public int? AnimalTypeId { get; set; }
        public AnimalType? AnimalType { get; set; }

        public int? CurrentAnimalId { get; set; }
        public Animal? CurrentAnimal { get; set; }

        public ICollection<AnimalMedicalRecord> MedicalRecords { get; set; } = new List<AnimalMedicalRecord>();
    }

}
