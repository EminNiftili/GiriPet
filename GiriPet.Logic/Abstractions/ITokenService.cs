namespace GiriPet.Logic.Abstractions
{
    public interface ITokenService
    {
        /// <summary>
        /// Generates a JWT token for the authenticated user.
        /// </summary>
        string GenerateToken(int userId, string email);

        int GetUserIdFromToken(string token);
    }
}
