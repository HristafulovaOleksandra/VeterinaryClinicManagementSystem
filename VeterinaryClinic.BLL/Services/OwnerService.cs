using System.Collections.Generic;
using System.Threading.Tasks;
using Mapster;
using VeterinaryClinic.BLL.DTOs.Owner;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.Entities.HelpModels;
using VeterinaryClinic.DAL.Helpers;
using VeterinaryClinic.DAL.UOW;

namespace VeterinaryClinic.BLL.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISortHelper<Owner> _sortHelper;

        public OwnerService(IUnitOfWork unitOfWork, ISortHelper<Owner> sortHelper)
        {
            _unitOfWork = unitOfWork;
            _sortHelper = sortHelper;
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

        public async Task<PagedList<OwnerDto>> GetAllAsync(OwnerParameters parameters)
        {
            var query = _unitOfWork.Owners.GetAllQueryable();

            if (!string.IsNullOrWhiteSpace(parameters.Name))
                query = query.Where(o => o.Name.Contains(parameters.Name));

            if (!string.IsNullOrWhiteSpace(parameters.PhoneNumber))
                query = query.Where(o => o.PhoneNumber.Contains(parameters.PhoneNumber));

            if (!string.IsNullOrWhiteSpace(parameters.Address))
                query = query.Where(o => o.Address != null && o.Address.Contains(parameters.Address));

            query = _sortHelper.ApplySort(query, parameters.OrderBy);

            var pagedList = await PagedList<Owner>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);
            var dtoList = pagedList.Select(x => x.Adapt<OwnerDto>()).ToList();

            return new PagedList<OwnerDto>(dtoList, pagedList.TotalCount, pagedList.CurrentPage, pagedList.PageSize);
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
