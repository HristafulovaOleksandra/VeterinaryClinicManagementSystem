using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.Owner;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<int> CreateAsync(CreateOwnerDto dto);
        Task UpdateAsync(OwnerDto dto);
        Task<OwnerDto?> GetByIdAsync(int id);
        Task<IEnumerable<OwnerDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
