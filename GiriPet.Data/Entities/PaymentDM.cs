namespace GiriPet.Data.Entities
{
    public class PaymentDM
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentStatus { get; set; } = null!;

        public AppointmentDM Appointment { get; set; } = null!;
    }
}
