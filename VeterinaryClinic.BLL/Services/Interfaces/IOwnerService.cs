using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.Owner;
using VeterinaryClinic.DAL.Entities.HelpModels;
using VeterinaryClinic.DAL.Helpers;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IOwnerService
    {
        Task<int> CreateAsync(CreateOwnerDto dto);
        Task UpdateAsync(OwnerDto dto);
        Task<OwnerDto?> GetByIdAsync(int id);
        Task<PagedList<OwnerDto>> GetAllAsync(OwnerParameters parameters);
        Task DeleteAsync(int id);
    }
}
