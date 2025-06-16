using Mapster;
using VeterinaryClinic.BLL.DTOs.AnimalDisease;
using VeterinaryClinic.BLL.Exceptions;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.UOW;

namespace VeterinaryClinic.BLL.Services
{
    public class AnimalDiseaseService : IAnimalDiseaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnimalDiseaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(CreateAnimalDiseaseDto dto)
        {
            var animalDisease = dto.Adapt<AnimalDisease>();
            await _unitOfWork.AnimalDiseases.AddAsync(animalDisease);
            await _unitOfWork.SaveAsync();
            return animalDisease.Id;
        }

        public async Task UpdateAsync(AnimalDiseaseDto dto)
        {
            var existingDisease = await GetExistingAnimalDiseaseOrThrowAsync(dto.Id);
            dto.Adapt(existingDisease);
            await _unitOfWork.AnimalDiseases.UpdateAsync(existingDisease);
            await _unitOfWork.SaveAsync();
        }

        public async Task<AnimalDiseaseDto?> GetByIdAsync(int id)
        {
            var animalDisease = await _unitOfWork.AnimalDiseases.GetByIdAsync(id);
            return animalDisease?.Adapt<AnimalDiseaseDto>();
        }

        public async Task<IEnumerable<AnimalDiseaseDto>> GetAllAsync()
        {
            var diseases = await _unitOfWork.AnimalDiseases.GetAllAsync();
            return diseases.Adapt<IEnumerable<AnimalDiseaseDto>>();
        }

        public async Task DeleteAsync(int id)
        {
            var animalDisease = await GetExistingAnimalDiseaseOrThrowAsync(id);
            await _unitOfWork.AnimalDiseases.DeleteAsync(animalDisease);
            await _unitOfWork.SaveAsync();
        }

        private async Task<AnimalDisease> GetExistingAnimalDiseaseOrThrowAsync(int id)
        {
            var animalDisease = await _unitOfWork.AnimalDiseases.GetByIdAsync(id);
            if (animalDisease == null)
                throw new NotFoundException($"AnimalDisease with ID {id} not found.");
            return animalDisease;
        }
    }
}
