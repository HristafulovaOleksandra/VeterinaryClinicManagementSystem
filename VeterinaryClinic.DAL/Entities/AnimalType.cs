using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.DAL.Entities
{
    public class AnimalType
    {
        public int Id { get; set; }
        public string AnimalTypeName { get; set; } = null!;

        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
        public ICollection<HospitalRoom> HospitalRooms { get; set; } = new List<HospitalRoom>();
    }

}
