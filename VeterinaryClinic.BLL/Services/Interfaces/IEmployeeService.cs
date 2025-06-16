using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.Employee;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> CreateAsync(CreateEmployeeDto dto);
        Task UpdateAsync(EmployeeDto dto);
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
