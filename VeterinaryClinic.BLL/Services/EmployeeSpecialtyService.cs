using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using VeterinaryClinic.BLL.DTOs.EmployeeSpecialty;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.UOW;

namespace VeterinaryClinic.BLL.Services
{
    public class EmployeeSpecialtyService : IEmployeeSpecialtyService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeSpecialtyService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(CreateEmployeeSpecialtyDto dto)
        {
            var entity = dto.Adapt<EmployeeSpecialty>();
            await _unitOfWork.EmployeeSpecialties.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(EmployeeSpecialtyDto dto)
        {
            var existing = await _unitOfWork.EmployeeSpecialties.GetByIdAsync(dto.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Specialty with ID {dto.Id} not found.");

            dto.Adapt(existing);
            await _unitOfWork.EmployeeSpecialties.UpdateAsync(existing);
            await _unitOfWork.SaveAsync();
        }

        public async Task<EmployeeSpecialtyDto?> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.EmployeeSpecialties.GetByIdAsync(id);
            return entity?.Adapt<EmployeeSpecialtyDto>();
        }

        public async Task<IEnumerable<EmployeeSpecialtyDto>> GetAllAsync()
        {
            var list = await _unitOfWork.EmployeeSpecialties.GetAllAsync();
            return list.Adapt<IEnumerable<EmployeeSpecialtyDto>>();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.EmployeeSpecialties.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Specialty with ID {id} not found.");

            await _unitOfWork.EmployeeSpecialties.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
