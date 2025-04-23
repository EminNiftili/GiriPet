using AutoMapper;
using GiriPet.Data.UnitOfWork;
using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;

namespace GiriPet.Logic.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Creates a new review and returns the created review ID.
        /// </summary>
        public async Task<int> CreateReviewAsync(ReviewDto dto)
        {
            var review = _mapper.Map<Data.Entities.ReviewDM>(dto);
            review.CreatedAt = DateTime.Now;

            await _unitOfWork.Reviews.AddAsync(review);
            await _unitOfWork.SaveChangesAsync();

            return review.Id;
        }

        /// <summary>
        /// Gets all reviews associated with a specific walker.
        /// </summary>
        public async Task<IEnumerable<ReviewDto>> GetReviewsByWalkerIdAsync(int walkerId)
        {
            var list = await _unitOfWork.Reviews.FindAsync(r => r.WalkerId == walkerId);
            return _mapper.Map<IEnumerable<ReviewDto>>(list);
        }
    }
}
