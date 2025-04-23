namespace GiriPet.Data.Entities
{
    public class ReviewDM
    {
        public int Id { get; set; }
        public int WalkerId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedAt { get; set; }

        public WalkerDM Walker { get; set; } = null!;
        public UserDM User { get; set; } = null!;
    }
}
