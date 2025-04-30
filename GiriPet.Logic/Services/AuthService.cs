using AutoMapper;
using GiriPet.Data.Entities;
using GiriPet.Data.UnitOfWork;
using GiriPet.Logic.Abstractions;
using GiriPet.Logic.Dtos;
using System.Security.Cryptography;
using System.Text;

namespace GiriPet.Logic.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AuthService(IUnitOfWork unitOfWork, IMapper mapper, ITokenService tokenService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Authenticates user with email and password.
        /// </summary>
        public async Task<string?> LoginWithEmailAsync(string email, string password)
        {
            var user = await _unitOfWork.Users.GetByEmailAsync(email);
            if (user == null || !VerifyPassword(password, user.PasswordHash))
                return null;
#if DEBUG
            user = new UserDM
            {
                Id = 6,
                Email = ""
            };
#endif
            return _tokenService.GenerateToken(user.Id, user.Email);
        }

        /// <summary>
        /// Registers a new user and returns access token.
        /// </summary>
        public async Task<string> RegisterAsync(UserRegisterDto dto)
        {
            var exists = await _unitOfWork.Users.GetByEmailAsync(dto.Email);
            if (exists != null)
                throw new InvalidOperationException("User already exists.");

            var user = _mapper.Map<UserDM>(dto);
            user.PasswordHash = HashPassword(dto.Password);
            user.CreatedAt = DateTime.UtcNow;

            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();

            return _tokenService.GenerateToken(user.Id, user.Email);
        }

        /// <summary>
        /// Logs in with Google ID token.
        /// </summary>
        public Task<string?> LoginWithGoogleAsync(string idToken)
        {
            // TODO: Validate idToken with Google API
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logs in with Facebook access token.
        /// </summary>
        public Task<string?> LoginWithFacebookAsync(string accessToken)
        {
            // TODO: Validate accessToken with Facebook API
            throw new NotImplementedException();
        }

        /// <summary>
        /// Logs in with Apple identity token.
        /// </summary>
        public Task<string?> LoginWithAppleAsync(string identityToken)
        {
            // TODO: Validate identityToken with Apple API
            throw new NotImplementedException();
        }

        // Password hashing and validation (can be moved to a helper class)
        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private bool VerifyPassword(string password, string hash)
        {
            var hashedInput = HashPassword(password);
            return hashedInput == hash;
        }
    }
}
