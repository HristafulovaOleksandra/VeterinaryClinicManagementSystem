using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.BLL.DTOs.Animal
{
    public class CreateAnimalDto
    {
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public int? OwnerId { get; set; }
        public int AnimalTypeId { get; set; }
    }
}
