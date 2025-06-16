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

namespace VeterinaryClinic.BLL.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public async Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            var employees = await _unitOfWork.Employees.GetAllAsync();
            return employees.Adapt<IEnumerable<EmployeeDto>>();
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
