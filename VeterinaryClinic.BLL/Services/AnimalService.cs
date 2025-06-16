using Mapster;
using VeterinaryClinic.BLL.DTOs.Animal;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.UOW;

namespace VeterinaryClinic.BLL.Services;

public class AnimalService : IAnimalService
{
    private readonly IUnitOfWork _unitOfWork;

    public AnimalService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
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

    public async Task<IEnumerable<AnimalDto>> GetAllAsync()
    {
        var animals = await _unitOfWork.Animals.GetAllAsync();
        return animals.Adapt<IEnumerable<AnimalDto>>();
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _unitOfWork.Animals.GetByIdAsync(id)
            ?? throw new Exception($"Animal with ID {id} not found.");

        await _unitOfWork.Animals.DeleteAsync(entity);
        await _unitOfWork.SaveAsync();
    }
}
