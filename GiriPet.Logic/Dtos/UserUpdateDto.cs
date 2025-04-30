using GiriPet.Logic.Enums;

namespace GiriPet.Logic.Dtos
{
    public class UserUpdateDto
    {
        public int Id { get; set; }  // Required to find the user
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? ImagePath { get; set; } = null!;
        public string? ImageAsBase64 { get; set; } = null!;
        public ImageAction ImageAction { get; set; }
    }
}
