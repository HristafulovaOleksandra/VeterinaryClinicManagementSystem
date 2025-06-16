using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VeterinaryClinic.BLL.DTOs.AnimalDisease
{
    public class AnimalDiseaseDto
    {
        public int Id { get; set; }
        public string DiseaseName { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
