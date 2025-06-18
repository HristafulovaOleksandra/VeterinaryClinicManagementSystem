using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using VeterinaryClinic.BLL.DTOs.HospitalRoom;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.Entities.HelpModels;
using VeterinaryClinic.DAL.Helpers;
using VeterinaryClinic.DAL.UOW;

namespace VeterinaryClinic.BLL.Services
{
    public class HospitalRoomService : IHospitalRoomService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISortHelper<HospitalRoom> _sortHelper;

        public HospitalRoomService(IUnitOfWork unitOfWork, ISortHelper<HospitalRoom> sortHelper)
        {
            _unitOfWork = unitOfWork;
            _sortHelper = sortHelper;
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

        public async Task<PagedList<HospitalRoomDto>> GetAllAsync(HospitalRoomParameters parameters)
        {
            var query = _unitOfWork.HospitalRooms.GetAllQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.RoomNumber))
                query = query.Where(r => r.RoomNumber.Contains(parameters.RoomNumber));

            if (parameters.DepartmentId.HasValue)
                query = query.Where(r => r.DepartmentId == parameters.DepartmentId);

            if (parameters.AnimalTypeId.HasValue)
                query = query.Where(r => r.AnimalTypeId == parameters.AnimalTypeId);

            if (parameters.CurrentAnimalId.HasValue)
                query = query.Where(r => r.CurrentAnimalId == parameters.CurrentAnimalId);

            query = _sortHelper.ApplySort(query, parameters.OrderBy);

            var pagedList = await PagedList<HospitalRoom>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);
            var dtoList = pagedList.Select(x => x.Adapt<HospitalRoomDto>()).ToList();

            return new PagedList<HospitalRoomDto>(dtoList, pagedList.TotalCount, pagedList.CurrentPage, pagedList.PageSize);
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
