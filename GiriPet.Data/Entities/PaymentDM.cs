namespace GiriPet.Data.Entities
{
    public class PaymentDM
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int PaymentStatus { get; set; }

        public AppointmentDM Appointment { get; set; } = null!;
    }
}
