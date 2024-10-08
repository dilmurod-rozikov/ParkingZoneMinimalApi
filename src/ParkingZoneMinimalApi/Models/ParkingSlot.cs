﻿using System.ComponentModel.DataAnnotations;
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

        public DateOnly CreatedDate { get; init; } = new DateOnly();

        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
