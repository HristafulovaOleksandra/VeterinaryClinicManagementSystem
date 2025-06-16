using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VeterinaryClinic.BLL.DTOs.HospitalRoom;

namespace VeterinaryClinic.BLL.Services.Interfaces
{
    public interface IHospitalRoomService
    {
        Task<int> CreateAsync(CreateHospitalRoomDto dto);
        Task UpdateAsync(HospitalRoomDto dto);
        Task<HospitalRoomDto?> GetByIdAsync(int id);
        Task<IEnumerable<HospitalRoomDto>> GetAllAsync();
        Task DeleteAsync(int id);
    }
}
