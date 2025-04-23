using GiriPet.Logic.Enums;

namespace GiriPet.Logic.Dtos
{
    public class AppointmentDto
    {
        public int Id { get; set; }
        public int PetId { get; set; }
        public int WalkerId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public AppointmentStatus Status { get; set; }
        public decimal Price { get; set; }
    }

}
