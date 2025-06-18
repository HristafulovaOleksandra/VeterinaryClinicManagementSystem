using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.DAL.Entities.HelpModels
{
    public class AnimalMedicalRecordParameters : QueryStringParameters
    {
        public int? AnimalId { get; set; }

        public int? DiseaseId { get; set; }

        public DateTime? DiagnosisDateFrom { get; set; }
        public DateTime? DiagnosisDateTo { get; set; }

        public string? TreatmentNotes { get; set; }

        public int? EmployeeId { get; set; }

        public int? RoomId { get; set; }

        public DateTime? AdmissionDateFrom { get; set; }
        public DateTime? AdmissionDateTo { get; set; }

        public DateTime? DischargeDateFrom { get; set; }
        public DateTime? DischargeDateTo { get; set; }
    }

}
