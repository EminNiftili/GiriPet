namespace GiriPet.Data.Entities
{
    public class UserDM
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public string? ImagePath { get; set; } = null!;

        public ICollection<PetDM> Pets { get; set; } = new List<PetDM>();
        public ICollection<ReviewDM> Reviews { get; set; } = new List<ReviewDM>();
    }
}
