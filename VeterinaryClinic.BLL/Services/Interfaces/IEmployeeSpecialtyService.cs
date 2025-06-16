using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.EmployeeSpecialty;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IEmployeeSpecialtyService
    {
        Task<int> CreateAsync(CreateEmployeeSpecialtyDto dto);
        Task UpdateAsync(EmployeeSpecialtyDto dto);
        Task<EmployeeSpecialtyDto?> GetByIdAsync(int id);
        Task<IEnumerable<EmployeeSpecialtyDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
