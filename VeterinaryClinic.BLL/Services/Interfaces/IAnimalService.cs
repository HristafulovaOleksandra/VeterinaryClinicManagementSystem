using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.Animal;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IAnimalService
    {
        Task<int> CreateAsync(CreateAnimalDto dto);
        Task UpdateAsync(AnimalDto dto);
        Task<AnimalDto?> GetByIdAsync(int id);
        Task<IEnumerable<AnimalDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
