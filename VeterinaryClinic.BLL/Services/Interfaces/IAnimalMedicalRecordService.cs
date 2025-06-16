using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.AnimalMedicalRecord;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IAnimalMedicalRecordService
    {
        Task<int> CreateAsync(CreateAnimalMedicalRecordDto dto);
        Task UpdateAsync(AnimalMedicalRecordDto dto);
        Task<AnimalMedicalRecordDto?> GetByIdAsync(int id);
        Task<IEnumerable<AnimalMedicalRecordDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
