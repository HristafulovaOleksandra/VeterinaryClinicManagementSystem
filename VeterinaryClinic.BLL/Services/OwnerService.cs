using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using VeterinaryClinic.BLL.DTOs.Owner;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.UOW;

namespace VeterinaryClinic.BLL.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OwnerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(CreateOwnerDto dto)
        {
            var entity = dto.Adapt<Owner>();
            await _unitOfWork.Owners.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(OwnerDto dto)
        {
            var existing = await _unitOfWork.Owners.GetByIdAsync(dto.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Owner with ID {dto.Id} not found.");

            dto.Adapt(existing);
            await _unitOfWork.Owners.UpdateAsync(existing);
            await _unitOfWork.SaveAsync();
        }

        public async Task<OwnerDto?> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.Owners.GetByIdAsync(id);
            return entity?.Adapt<OwnerDto>();
        }

        public async Task<IEnumerable<OwnerDto>> GetAllAsync()
        {
            var list = await _unitOfWork.Owners.GetAllAsync();
            return list.Adapt<IEnumerable<OwnerDto>>();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.Owners.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Owner with ID {id} not found.");

            await _unitOfWork.Owners.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
