using GiriPet.Logic.Dtos;

namespace GiriPet.Logic.Abstractions
{
    public interface IAuthService
    {
        /// <summary>
        /// Logs in a user using email and password credentials.
        /// Returns a JWT token if successful, otherwise null.
        /// </summary>
        Task<string?> LoginWithEmailAsync(string email, string password);

        /// <summary>
        /// Logs in or registers a user using Google sign-in ID token.
        /// Returns a JWT token if successful, otherwise null.
        /// </summary>
        Task<string?> LoginWithGoogleAsync(string idToken);

        /// <summary>
        /// Logs in or registers a user using Facebook access token.
        /// Returns a JWT token if successful, otherwise null.
        /// </summary>
        Task<string?> LoginWithFacebookAsync(string accessToken);

        /// <summary>
        /// Logs in or registers a user using Apple ID token.
        /// Returns a JWT token if successful, otherwise null.
        /// </summary>
        Task<string?> LoginWithAppleAsync(string identityToken);

        /// <summary>
        /// Registers a new user with email and password credentials.
        /// Returns a JWT token upon successful registration.
        /// </summary>
        Task<string> RegisterAsync(UserRegisterDto dto);
    }

}
