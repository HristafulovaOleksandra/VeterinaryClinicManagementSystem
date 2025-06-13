using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.DAL.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime BirthDate { get; set; }

        public int? OwnerId { get; set; }
        public Owner? Owner { get; set; }

        public int AnimalTypeId { get; set; }
        public AnimalType AnimalType { get; set; } = null!;

        public ICollection<AnimalMedicalRecord> MedicalRecords { get; set; } = new List<AnimalMedicalRecord>();
    }
}
