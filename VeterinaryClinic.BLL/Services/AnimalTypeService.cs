using Mapster;
using VeterinaryClinic.BLL.DTOs.AnimalType;
using VeterinaryClinic.BLL.Exceptions;
using VeterinaryClinic.BLL.Services.Interfaces;
using VeterinaryClinic.DAL.Entities;
using VeterinaryClinic.DAL.UOW;

using Microsoft.IdentityModel.SecurityTokenService;
namespace VeterinaryClinic.BLL.Services
{
    public class AnimalTypeService : IAnimalTypeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnimalTypeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<int> CreateAsync(CreateAnimalTypeDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.AnimalTypeName))
                throw new BadRequestException("Animal type name cannot be empty.");

            var entity = dto.Adapt<AnimalType>();
            await _unitOfWork.AnimalTypes.AddAsync(entity);
            await _unitOfWork.SaveAsync();
            return entity.Id;
        }



        public async Task UpdateAsync(AnimalTypeDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.AnimalTypeName))
                throw new BadRequestException("Animal type name cannot be empty.");

            var entity = await _unitOfWork.AnimalTypes.GetByIdAsync(dto.Id)
                ?? throw new NotFoundException($"AnimalType with ID {dto.Id} not found.");

            dto.Adapt(entity);
            await _unitOfWork.AnimalTypes.UpdateAsync(entity);
            await _unitOfWork.SaveAsync();
        }



        public async Task<AnimalTypeDto?> GetByIdAsync(int id)
        {
            var entity = await _unitOfWork.AnimalTypes.GetByIdAsync(id);
            return entity?.Adapt<AnimalTypeDto>();
        }

        public async Task<IEnumerable<AnimalTypeDto>> GetAllAsync()
        {
            var entities = await _unitOfWork.AnimalTypes.GetAllAsync();
            return entities.Adapt<IEnumerable<AnimalTypeDto>>();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _unitOfWork.AnimalTypes.GetByIdAsync(id);
            if (entity == null)
                throw new NotFoundException($"AnimalType with ID {id} not found.");

            await _unitOfWork.AnimalTypes.DeleteAsync(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
