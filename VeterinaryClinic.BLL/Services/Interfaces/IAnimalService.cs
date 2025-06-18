using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.Animal;
using VeterinaryClinic.DAL.Entities.HelpModels;
using VeterinaryClinic.DAL.Helpers;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IAnimalService
    {
        Task<int> CreateAsync(CreateAnimalDto dto);
        Task UpdateAsync(AnimalDto dto);
        Task<AnimalDto?> GetByIdAsync(int id);
        Task<PagedList<AnimalDto>> GetAllAsync(AnimalParameters parameters);
        Task DeleteAsync(int id);

    }
}
