using AutoMapper;
using GiriPet.Data.UnitOfWork;
using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;

namespace GiriPet.Logic.Services
{
    public class PetService : IPetService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PetService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> CreatePetAsync(PetDto dto)
        {
            if (!await CanInteractPet(dto.UserId))
            {
                return -1;
            }
            var entity = _mapper.Map<Data.Entities.PetDM>(dto);
            await _unitOfWork.Pets.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<bool> UpdatePetAsync(PetDto dto)
        {
            if (!await CanInteractPet(dto.UserId))
            {
                return false;
            }
            var existing = await _unitOfWork.Pets.GetByIdAsync(dto.Id);
            if (existing == null)
                return false;

            existing.Name = dto.Name;
            existing.Species = dto.Species;
            existing.Breed = dto.Breed;
            existing.Age = dto.Age;
            existing.Size = dto.Size;
            existing.Notes = dto.Notes;
            _unitOfWork.Pets.Update(existing);
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
