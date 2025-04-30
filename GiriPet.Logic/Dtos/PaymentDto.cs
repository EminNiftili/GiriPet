using GiriPet.Logic.Enums;

namespace GiriPet.Logic.Dtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int AppointmentId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
    }

}
