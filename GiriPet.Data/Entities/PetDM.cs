namespace GiriPet.Data.Entities
{
    public class PetDM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string Breed { get; set; } = null!;
        public int Age { get; set; }
        public string Size { get; set; } = null!;
        public string? Notes { get; set; }
        public string? ImagePath { get; set; } = null!;

        public UserDM User { get; set; } = null!;
        public ICollection<AppointmentDM> Appointments { get; set; } = new List<AppointmentDM>();
    }
}
