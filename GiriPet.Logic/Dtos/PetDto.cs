namespace GiriPet.Logic.Dtos
{
    public class PetDto
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
    }

}
