namespace GiriPet.Data.Entities
{
    public class AppointmentDM
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int WalkerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int StatusId { get; set; }
        public decimal Price { get; set; }

        public PetDM Pet { get; set; } = null!;
        public WalkerDM Walker { get; set; } = null!;
        public PaymentDM? Payment { get; set; }
    }
}
