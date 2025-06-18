using Mapster;
using VeterinaryClinic.BLL.DTOs.AnimalMedicalRecord;
using VeterinaryClinic.BLL.Exceptions;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.Entities.HelpModels;
using VeterinaryClinic.DAL.Helpers;
using VeterinaryClinic.DAL.UOW;

namespace VeterinaryClinic.BLL.Services
{
    public class AnimalMedicalRecordService : IAnimalMedicalRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISortHelper<AnimalMedicalRecord> _sortHelper;
        public AnimalMedicalRecordService(IUnitOfWork unitOfWork, ISortHelper<AnimalMedicalRecord> sortHelper)
        {
            _unitOfWork = unitOfWork;
            _sortHelper = sortHelper;
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

        public async Task<PagedList<AnimalMedicalRecordDto>> GetAllAsync(AnimalMedicalRecordParameters parameters)
        {
            var query = _unitOfWork.AnimalMedicalRecords.GetAllQueryable();

            if (parameters.AnimalId.HasValue)
                query = query.Where(x => x.AnimalId == parameters.AnimalId.Value);

            if (parameters.DiseaseId.HasValue)
                query = query.Where(x => x.DiseaseId == parameters.DiseaseId.Value);

            if (parameters.DiagnosisDateFrom.HasValue)
                query = query.Where(x => x.DiagnosisDate >= parameters.DiagnosisDateFrom.Value);

            if (parameters.DiagnosisDateTo.HasValue)
                query = query.Where(x => x.DiagnosisDate <= parameters.DiagnosisDateTo.Value);

            if (!string.IsNullOrEmpty(parameters.TreatmentNotes))
                query = query.Where(x => x.TreatmentNotes.Contains(parameters.TreatmentNotes));

            if (parameters.EmployeeId.HasValue)
                query = query.Where(x => x.EmployeeId == parameters.EmployeeId.Value);

            if (parameters.RoomId.HasValue)
                query = query.Where(x => x.RoomId == parameters.RoomId.Value);

            if (parameters.AdmissionDateFrom.HasValue)
                query = query.Where(x => x.AdmissionDate >= parameters.AdmissionDateFrom.Value);

            if (parameters.AdmissionDateTo.HasValue)
                query = query.Where(x => x.AdmissionDate <= parameters.AdmissionDateTo.Value);

            if (parameters.DischargeDateFrom.HasValue)
                query = query.Where(x => x.DischargeDate >= parameters.DischargeDateFrom.Value);

            if (parameters.DischargeDateTo.HasValue)
                query = query.Where(x => x.DischargeDate <= parameters.DischargeDateTo.Value);

            query = _sortHelper.ApplySort(query, parameters.OrderBy);

            var pagedList = await PagedList<AnimalMedicalRecord>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);

            var dtoList = pagedList.Select(x => x.Adapt<AnimalMedicalRecordDto>()).ToList();

            return new PagedList<AnimalMedicalRecordDto>(dtoList, pagedList.TotalCount, pagedList.CurrentPage, pagedList.PageSize);
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
