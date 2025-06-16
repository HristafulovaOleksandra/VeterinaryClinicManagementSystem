using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.HospitalDepartment;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IHospitalDepartmentService
    {
        Task<int> CreateAsync(CreateHospitalDepartmentDto dto);
        Task UpdateAsync(HospitalDepartmentDto dto);
        Task<HospitalDepartmentDto?> GetByIdAsync(int id);
        Task<IEnumerable<HospitalDepartmentDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
