using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.BLL.DTOs.HospitalRoom
{
    public class CreateHospitalRoomDto
    {
        public string RoomNumber { get; set; } = string.Empty;
        public int? DepartmentId { get; set; }
        public int? AnimalTypeId { get; set; }
        public int? CurrentAnimalId { get; set; }
    }
}
