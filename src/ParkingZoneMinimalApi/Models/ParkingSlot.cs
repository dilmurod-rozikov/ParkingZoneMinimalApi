using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingZoneMinimalApi.Models
{
    public class ParkingSlot
    {
        [Key]
        public int Id { get; init; }

        [Range(0, short.MaxValue)]
        public short SlotNumber { get; set; }

        public bool IsLocked { get; set; }

        public virtual ParkingZone ParkingZone { get; set; }

        [ForeignKey(nameof(ParkingZone))]
        public int ParkingZoneId { get; set; }

        [MaxLength(25)]
        [MinLength(3)]
        public string Name { get; set; }

        [MaxLength(100)]
        [MinLength(10)]
        public string Address { get; set; }

        public DateOnly CreatedDate { get; init; } = new DateOnly();

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
