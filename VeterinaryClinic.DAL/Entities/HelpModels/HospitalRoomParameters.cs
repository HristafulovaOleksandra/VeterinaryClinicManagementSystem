using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.DAL.Entities.HelpModels
{
    public class HospitalRoomParameters : QueryStringParameters
    {
        public string? RoomNumber { get; set; }
        public int? DepartmentId { get; set; }
        public int? AnimalTypeId { get; set; }
        public int? CurrentAnimalId { get; set; }
    }
}
