using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using VeterinaryClinic.BLL.DTOs.HospitalRoom;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.UOW;

namespace VeterinaryClinic.BLL.Services
{
    public class HospitalRoomService : IHospitalRoomService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HospitalRoomService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(CreateHospitalRoomDto dto)
        {
            var entity = dto.Adapt<HospitalRoom>();
            await _unitOfWork.HospitalRooms.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(HospitalRoomDto dto)
        {
            var existing = await _unitOfWork.HospitalRooms.GetByIdAsync(dto.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Hospital room with ID {dto.Id} not found.");

            dto.Adapt(existing);
            await _unitOfWork.HospitalRooms.UpdateAsync(existing);
            await _unitOfWork.SaveAsync();
        }

        public async Task<HospitalRoomDto?> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.HospitalRooms.GetByIdAsync(id);
            return entity?.Adapt<HospitalRoomDto>();
        }

        public async Task<IEnumerable<HospitalRoomDto>> GetAllAsync()
        {
            var list = await _unitOfWork.HospitalRooms.GetAllAsync();
            return list.Adapt<IEnumerable<HospitalRoomDto>>();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.HospitalRooms.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Hospital room with ID {id} not found.");

            await _unitOfWork.HospitalRooms.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
