using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.BLL.DTOs.AnimalMedicalRecord
{
    public class AnimalMedicalRecordDto
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public int? DiseaseId { get; set; }
        public DateTime DiagnosisDate { get; set; }
        public string? TreatmentNotes { get; set; }
        public int? EmployeeId { get; set; }
        public int? RoomId { get; set; }
        public DateTime? AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
    }
}
