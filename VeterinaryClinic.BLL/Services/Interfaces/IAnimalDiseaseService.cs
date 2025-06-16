using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.AnimalDisease;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IAnimalDiseaseService
    {
        Task<int> CreateAsync(CreateAnimalDiseaseDto dto);
        Task UpdateAsync(AnimalDiseaseDto dto);
        Task<AnimalDiseaseDto?> GetByIdAsync(int id);
        Task<IEnumerable<AnimalDiseaseDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }

}
