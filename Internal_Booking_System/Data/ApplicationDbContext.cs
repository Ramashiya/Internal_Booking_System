using InternalBookingSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace InternalBookingSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Resource> Resources { get; set; }
        public DbSet<Booking> Bookings { get; set; }

    }
}
