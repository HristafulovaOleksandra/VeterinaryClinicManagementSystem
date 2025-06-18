using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.HospitalRoom;
using VeterinaryClinic.DAL.Entities.HelpModels;
using VeterinaryClinic.DAL.Helpers;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IHospitalRoomService
    {
        Task<int> CreateAsync(CreateHospitalRoomDto dto);
        Task UpdateAsync(HospitalRoomDto dto);
        Task<HospitalRoomDto?> GetByIdAsync(int id);
        Task<PagedList<HospitalRoomDto>> GetAllAsync(HospitalRoomParameters parameters);
        Task DeleteAsync(int id);
    }
}
