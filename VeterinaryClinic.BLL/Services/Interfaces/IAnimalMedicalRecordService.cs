using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.AnimalMedicalRecord;
using VeterinaryClinic.DAL.Entities.HelpModels;
using VeterinaryClinic.DAL.Helpers;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IAnimalMedicalRecordService
    {
        Task<int> CreateAsync(CreateAnimalMedicalRecordDto dto);
        Task UpdateAsync(AnimalMedicalRecordDto dto);
        Task<PagedList<AnimalMedicalRecordDto>> GetAllAsync(AnimalMedicalRecordParameters parameters);
        Task<AnimalMedicalRecordDto?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
