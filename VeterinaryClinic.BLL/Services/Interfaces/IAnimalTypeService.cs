using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.AnimalType;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IAnimalTypeService
    {
        Task<int> CreateAsync(CreateAnimalTypeDto dto);
        Task UpdateAsync(AnimalTypeDto dto);
        Task<AnimalTypeDto?> GetByIdAsync(int id);
        Task<IEnumerable<AnimalTypeDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
