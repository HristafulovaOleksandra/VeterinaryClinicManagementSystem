using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.DAL.Entities
{
    public class AnimalDisease
    {
        public int Id { get; set; }
        public string DiseaseName { get; set; } = null!;
        public string? Description { get; set; }

        public ICollection<AnimalMedicalRecord> MedicalRecords { get; set; } = new List<AnimalMedicalRecord>();
    }

}
