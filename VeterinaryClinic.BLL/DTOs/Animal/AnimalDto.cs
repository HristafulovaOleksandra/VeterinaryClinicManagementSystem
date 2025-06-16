using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.DAL.Entities;

namespace VeterinaryClinic.BLL.DTOs.Animal
{
    public class AnimalDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string? OwnerName { get; set; }
        public int AnimalTypeId { get; set; }
    }
}
