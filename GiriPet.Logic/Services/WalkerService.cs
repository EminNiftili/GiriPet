using AutoMapper;
using GiriPet.Data.UnitOfWork;
using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;

namespace GiriPet.Logic.Services
{
    public class WalkerService : IWalkerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public WalkerService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new walker profile and returns the new walker ID.
        /// </summary>
        public async Task<int> CreateWalkerAsync(WalkerDto dto)
        {
            var entity = _mapper.Map<Data.Entities.WalkerDM>(dto);
            entity.Rating = 0.0; // default rating on create

            await _unitOfWork.Walkers.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();

            return entity.Id;
        }

        /// <summary>
        /// Updates walker profile information.
        /// </summary>
        public async Task<bool> UpdateWalkerAsync(WalkerDto dto)
        {
            var walker = await _unitOfWork.Walkers.GetByIdAsync(dto.Id);
            if (walker == null)
                return false;

            walker.Bio = dto.Bio;
            walker.City = dto.City;
            walker.ExperienceYears = dto.ExperienceYears;

            _unitOfWork.Walkers.Update(walker);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Gets walker profile by user ID.
        /// </summary>
        public async Task<WalkerDto?> GetByUserIdAsync(int userId)
        {
            var walker = (await _unitOfWork.Walkers
                .FindAsync(w => w.UserId == userId)).FirstOrDefault();

            return walker == null ? null : _mapper.Map<WalkerDto>(walker);
        }
    }
}
