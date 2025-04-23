namespace GiriPet.Logic.Dtos
{
    public class UserUpdateDto
    {
        public int Id { get; set; }  // Required to find the user
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
