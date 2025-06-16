using Mapster;
using VeterinaryClinic.BLL.DTOs.AnimalMedicalRecord;
using VeterinaryClinic.BLL.Exceptions;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.UOW;

namespace VeterinaryClinic.BLL.Services
{
    public class AnimalMedicalRecordService : IAnimalMedicalRecordService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnimalMedicalRecordService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(CreateAnimalMedicalRecordDto dto)
        {
            var record = dto.Adapt<AnimalMedicalRecord>();
            await _unitOfWork.AnimalMedicalRecords.AddAsync(record);
            await _unitOfWork.SaveAsync();
            return record.Id;
        }

        public async Task UpdateAsync(AnimalMedicalRecordDto dto)
        {
            var existingRecord = await GetExistingRecordOrThrowAsync(dto.Id);
            dto.Adapt(existingRecord);
            await _unitOfWork.AnimalMedicalRecords.UpdateAsync(existingRecord);
            await _unitOfWork.SaveAsync();
        }

        public async Task<AnimalMedicalRecordDto?> GetByIdAsync(int id)
        {
            var record = await _unitOfWork.AnimalMedicalRecords.GetByIdAsync(id);
            return record?.Adapt<AnimalMedicalRecordDto>();
        }

        public async Task<IEnumerable<AnimalMedicalRecordDto>> GetAllAsync()
        {
            var records = await _unitOfWork.AnimalMedicalRecords.GetAllAsync();
            return records.Adapt<IEnumerable<AnimalMedicalRecordDto>>();
        }

        public async Task DeleteAsync(int id)
        {
            var record = await GetExistingRecordOrThrowAsync(id);
            await _unitOfWork.AnimalMedicalRecords.DeleteAsync(record);
            await _unitOfWork.SaveAsync();
        }

        private async Task<AnimalMedicalRecord> GetExistingRecordOrThrowAsync(int id)
        {
            var record = await _unitOfWork.AnimalMedicalRecords.GetByIdAsync(id);
            if (record == null)
                throw new NotFoundException($"AnimalMedicalRecord with ID {id} not found.");
            return record;
        }
    }
}
