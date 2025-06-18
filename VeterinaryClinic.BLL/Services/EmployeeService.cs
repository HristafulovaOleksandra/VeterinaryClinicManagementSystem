using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.BLL.DTOs.Employee;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.UOW;
using Mapster;
using VeterinaryClinic.BLL.Exceptions;
using VeterinaryClinic.DAL.Helpers;
using VeterinaryClinic.DAL.Entities.HelpModels;

namespace VeterinaryClinic.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISortHelper<Employee> _sortHelper;
        public EmployeeService(IUnitOfWork unitOfWork, ISortHelper<Employee> sortHelper)
        {
            _unitOfWork = unitOfWork;
            _sortHelper = sortHelper;
        }

        public async Task<int> CreateAsync(CreateEmployeeDto dto)
        {
            var employee = dto.Adapt<Employee>();
            await _unitOfWork.Employees.AddAsync(employee);
            await _unitOfWork.SaveAsync();
            return employee.Id;
        }

        public async Task UpdateAsync(EmployeeDto dto)
        {
            var existingEmployee = await _unitOfWork.Employees.GetByIdAsync(dto.Id);
            if (existingEmployee == null)
                throw new KeyNotFoundException($"Employee with id {dto.Id} not found.");

            dto.Adapt(existingEmployee);
            await _unitOfWork.Employees.UpdateAsync(existingEmployee);
            await _unitOfWork.SaveAsync();
        }

        public async Task<EmployeeDto?> GetByIdAsync(int id)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(id);
            return employee?.Adapt<EmployeeDto>();
        }

        public async Task<PagedList<EmployeeDto>> GetAllAsync(EmployeeParameters parameters)
        {
            var query = _unitOfWork.Employees.GetAllQueryable();

            if (!string.IsNullOrEmpty(parameters.Name))
                query = query.Where(e => e.Name.Contains(parameters.Name));

            if (!string.IsNullOrEmpty(parameters.PhoneNumber))
                query = query.Where(e => e.PhoneNumber.Contains(parameters.PhoneNumber));

            if (!string.IsNullOrEmpty(parameters.Address))
                query = query.Where(e => e.Address.Contains(parameters.Address));

            if (parameters.DepartmentId.HasValue)
                query = query.Where(e => e.DepartmentId == parameters.DepartmentId.Value);

            if (parameters.SpecialtyId.HasValue)
                query = query.Where(e => e.SpecialtyId == parameters.SpecialtyId.Value);

            query = _sortHelper.ApplySort(query, parameters.OrderBy);

            var pagedList = await PagedList<Employee>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);

            var dtoList = pagedList.Select(e => e.Adapt<EmployeeDto>()).ToList();

            return new PagedList<EmployeeDto>(dtoList, pagedList.TotalCount, pagedList.CurrentPage, pagedList.PageSize);
        }

        public async Task DeleteAsync(int id)
        {
            var query = await _unitOfWork.AnimalMedicalRecords
                .FindByCondotion(r => r.EmployeeId == id);
            if (await query.AnyAsync())
                throw new ConflictException("Cannot delete employee — they are referenced in medical records.");

            var employee = await _unitOfWork.Employees.GetByIdAsync(id)
                ?? throw new NotFoundException($"Employee with ID {id} not found.");

            await _unitOfWork.Employees.DeleteAsync(employee);
            await _unitOfWork.SaveAsync();
        }
    }
}
