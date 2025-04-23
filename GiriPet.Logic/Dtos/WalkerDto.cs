namespace GiriPet.Logic.Dtos
{
    public class WalkerDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Bio { get; set; } = null!;
        public string City { get; set; } = null!;
        public double Rating { get; set; }
        public int ExperienceYears { get; set; }
    }

}
