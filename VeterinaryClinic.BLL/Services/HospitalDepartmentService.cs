using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using VeterinaryClinic.BLL.DTOs.HospitalDepartment;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.UOW;

namespace VeterinaryClinic.BLL.Services
{
    public class HospitalDepartmentService : IHospitalDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public HospitalDepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(CreateHospitalDepartmentDto dto)
        {
            var entity = dto.Adapt<HospitalDepartment>();
            await _unitOfWork.HospitalDepartments.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(HospitalDepartmentDto dto)
        {
            var existing = await _unitOfWork.HospitalDepartments.GetByIdAsync(dto.Id);
            if (existing == null)
                throw new KeyNotFoundException($"Department with ID {dto.Id} not found.");

            dto.Adapt(existing);
            await _unitOfWork.HospitalDepartments.UpdateAsync(existing);
            await _unitOfWork.SaveAsync();
        }

        public async Task<HospitalDepartmentDto?> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.HospitalDepartments.GetByIdAsync(id);
            return entity?.Adapt<HospitalDepartmentDto>();
        }

        public async Task<IEnumerable<HospitalDepartmentDto>> GetAllAsync()
        {
            var list = await _unitOfWork.HospitalDepartments.GetAllAsync();
            return list.Adapt<IEnumerable<HospitalDepartmentDto>>();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.HospitalDepartments.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"Department with ID {id} not found.");

            await _unitOfWork.HospitalDepartments.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
