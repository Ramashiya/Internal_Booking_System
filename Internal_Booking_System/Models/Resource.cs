using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternalBookingSystem.Models
{
    public class Resource
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public int Capacity { get; set; }

        public bool IsAvailable { get; set; }

        // Navigation property
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
