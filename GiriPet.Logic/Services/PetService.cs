using AutoMapper;
using GiriPet.Data.UnitOfWork;
using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;
using GiriPet.Logic.Enums;

namespace GiriPet.Logic.Services
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IImageService _imageService;

        public PetService(IUnitOfWork unitOfWork, 
                          IMapper mapper,
                          IImageService imageService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageService = imageService;
        }

        public async Task<int> CreatePetAsync(PetDto dto)
        {
            if (!await CanInteractPet(dto.UserId))
            {
                return -1;
            }
            var pet = _mapper.Map<Data.Entities.PetDM>(dto);
            pet.ImagePath = _imageService.Action($"{pet.UserId}\\", dto.ImageAsBase64, dto.ImageAction, pet.ImagePath);
            await _unitOfWork.Pets.AddAsync(pet);
            await _unitOfWork.SaveChangesAsync();
            return pet.Id;
        }

        public async Task<bool> UpdatePetAsync(PetDto dto)
        {
            if (!await CanInteractPet(dto.UserId))
            {
                return false;
            }
            var existPet = await _unitOfWork.Pets.GetByIdAsync(dto.Id);
            if (existPet == null)
                return false;
            existPet = new();
            existPet.ImagePath = _imageService.Action($"{existPet.UserId}\\", dto.ImageAsBase64 , dto.ImageAction, existPet.ImagePath);
            existPet.Name = dto.Name;
            existPet.Species = dto.Species;
            existPet.Breed = dto.Breed;
            existPet.Age = dto.Age;
            existPet.Size = dto.Size;
            existPet.Notes = dto.Notes;
            _unitOfWork.Pets.Update(existPet);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<PetDto>> GetPetsByUserIdAsync(int userId)
        {
            var pets = await _unitOfWork.Pets.FindAsync(p => p.UserId == userId);
            return _mapper.Map<IEnumerable<PetDto>>(pets);
        }

        public async Task<PetDto?> GetByIdAsync(int id)
        {
            var pet = await _unitOfWork.Pets.GetByIdAsync(id);
            return pet == null ? null : _mapper.Map<PetDto>(pet);
        }

        private async Task<bool> CanInteractPet(int userId)
        {
            var user = await _unitOfWork.Walkers.FindAsync(x => x.UserId == userId);
            if(user.Any())
            {
                return false;
            }
            return true;
        }

    }
}
