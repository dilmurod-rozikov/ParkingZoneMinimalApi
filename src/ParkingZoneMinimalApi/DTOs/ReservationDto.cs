using ParkingZoneMinimalApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkingZoneMinimalApi.DTOs
{
    public class ReservationDto
    {
        [Key]
        public int Id { get; set; }

        public DateTime CreatedAt { get; init; } = DateTime.Now;

        [Range(1, 10000)]
        public short Duration { get; set; }

        [ForeignKey(nameof(ParkingSlot))]
        public int ParkingSlotId { get; set; }

        [Required]
        [MaxLength(20)]
        public string VehicleNo { get; set; }
    }
}
