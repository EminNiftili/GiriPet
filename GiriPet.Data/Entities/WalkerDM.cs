namespace GiriPet.Data.Entities
{
    public class WalkerDM
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Bio { get; set; } = null!;
        public string City { get; set; } = null!;
        public double Rating { get; set; }
        public int ExperienceYears { get; set; }

        public UserDM User { get; set; } = null!;
        public ICollection<AppointmentDM> Appointments { get; set; } = new List<AppointmentDM>();
        public ICollection<ReviewDM> Reviews { get; set; } = new List<ReviewDM>();
    }
}
