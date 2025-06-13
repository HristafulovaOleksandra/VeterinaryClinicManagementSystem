using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.DAL.Entities
{
    public class AnimalMedicalRecord
    {
        public int Id { get; set; }

        public int AnimalId { get; set; }
        public Animal Animal { get; set; } = null!;

        public int? DiseaseId { get; set; }
        public AnimalDisease? Disease { get; set; }

        public DateTime DiagnosisDate { get; set; }
        public string? TreatmentNotes { get; set; }

        public int? EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public int? RoomId { get; set; }
        public HospitalRoom? Room { get; set; }

        public DateTime? AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
    }

}
