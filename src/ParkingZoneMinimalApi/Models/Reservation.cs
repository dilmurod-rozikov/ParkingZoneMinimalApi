using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingZoneMinimalApi.Models
{
    public class Reservation
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; init; } = DateTime.Now;

        [Range(1, 10000)]
        public short Duration { get; set; }

        public virtual ParkingSlot ParkingSlot { get; set; }

        [ForeignKey(nameof(ParkingSlot))]
        public int ParkingSlotId { get; set; }

        [Required]
        [MaxLength(20)]
        public string VehicleNo { get; set; }
    }
}
