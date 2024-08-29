using System.ComponentModel.DataAnnotations;

namespace ParkingZoneMinimalApi.Models
{
    public class ParkingZone
    {
        [Key]
        public int Id { get; init; }

        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }

        [MaxLength(100)]
        [MinLength(10)]
        public string Address { get; set; }

        public DateOnly CreatedDate { get; init; } = new DateOnly();

        public ICollection<ParkingSlot> ParkingSlots { get; set; }
    }
}
