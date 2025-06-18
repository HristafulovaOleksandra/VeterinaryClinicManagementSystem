using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.Employee;
using VeterinaryClinic.DAL.Entities.HelpModels;
using VeterinaryClinic.DAL.Helpers;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> CreateAsync(CreateEmployeeDto dto);
        Task UpdateAsync(EmployeeDto dto);
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task<PagedList<EmployeeDto>> GetAllAsync(EmployeeParameters parameters);
        Task DeleteAsync(int id);
    }
}
