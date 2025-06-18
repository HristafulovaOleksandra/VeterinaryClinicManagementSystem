using Mapster;
using Microsoft.EntityFrameworkCore;
using VeterinaryClinic.BLL.DTOs.Animal;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.Entities.HelpModels;
using VeterinaryClinic.DAL.Helpers;
using VeterinaryClinic.DAL.UOW;

namespace VeterinaryClinic.BLL.Services;

public class AnimalService : IAnimalService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ISortHelper<Animal> _sortHelper;
    public AnimalService(IUnitOfWork unitOfWork, ISortHelper<Animal> sortHelper)
    {
        _unitOfWork = unitOfWork;
        _sortHelper = sortHelper;
    }

    public async Task<int> CreateAsync(CreateAnimalDto dto)
    {
        var animal = dto.Adapt<Animal>();
        var created = await _unitOfWork.Animals.AddAsync(animal);
        await _unitOfWork.SaveAsync();
        return created.Id;
    }

    public async Task UpdateAsync(AnimalDto dto)
    {
        var existing = await _unitOfWork.Animals.GetByIdAsync(dto.Id)
            ?? throw new Exception($"Animal with ID {dto.Id} not found.");

        dto.Adapt(existing);
        await _unitOfWork.Animals.UpdateAsync(existing);
        await _unitOfWork.SaveAsync();
    }

    public async Task<AnimalDto?> GetByIdAsync(int id)
    {
        var animal = await _unitOfWork.Animals.GetCompleteEntityAsync(id);
        return animal?.Adapt<AnimalDto>();
    }

    public async Task<PagedList<AnimalDto>> GetAllAsync(AnimalParameters parameters)
    {
        var query = _unitOfWork.Animals.GetAllQueryable();

        if (!string.IsNullOrEmpty(parameters.Name))
            query = query.Where(a => a.Name.Contains(parameters.Name));

        if (parameters.AnimalTypeId.HasValue)
            query = query.Where(a => a.AnimalTypeId == parameters.AnimalTypeId.Value);

        if (parameters.OwnerId.HasValue)
            query = query.Where(a => a.OwnerId == parameters.OwnerId.Value);

        if (parameters.MinAge.HasValue)
        {
            var minBirthDate = DateTime.UtcNow.AddYears(-parameters.MinAge.Value);
            query = query.Where(a => a.BirthDate <= minBirthDate);
        }

        if (parameters.MaxAge.HasValue)
        {
            var maxBirthDate = DateTime.UtcNow.AddYears(-parameters.MaxAge.Value);
            query = query.Where(a => a.BirthDate >= maxBirthDate);
        }

        query = _sortHelper.ApplySort(query, parameters.OrderBy);

        var pagedAnimals = await PagedList<Animal>.ToPagedListAsync(query, parameters.PageNumber, parameters.PageSize);

        var animalsDto = pagedAnimals.Select(a => a.Adapt<AnimalDto>()).ToList();

        return new PagedList<AnimalDto>(animalsDto, pagedAnimals.TotalCount, pagedAnimals.CurrentPage, pagedAnimals.PageSize);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _unitOfWork.Animals.GetByIdAsync(id)
            ?? throw new Exception($"Animal with ID {id} not found.");

        await _unitOfWork.Animals.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
    }
}
