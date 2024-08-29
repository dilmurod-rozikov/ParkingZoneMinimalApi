using ParkingZoneMinimalApi.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ParkingZoneMinimalApi.DTOs
{
    public class ParkingSlotDto
    {
        [Key]
        public int Id { get; init; }

        [Range(0, short.MaxValue)]
        public short SlotNumber { get; set; }

        public bool IsLocked { get; set; }

        [ForeignKey(nameof(ParkingZone))]
        public int ParkingZoneId { get; set; }

        public DateOnly CreatedDate { get; init; } = new DateOnly();
    }
}
