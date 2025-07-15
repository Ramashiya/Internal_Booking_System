using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternalBookingSystem.Data;
using InternalBookingSystem.Models;

namespace Internal_Booking_System.Controllers
{
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var bookings = _context.Bookings.Include(b => b.Resource);
            return View(await bookings.ToListAsync());
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var booking = await _context.Bookings
                .Include(b => b.Resource)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["ResourceId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                _context.Resources.Where(r => r.IsAvailable), "Id", "Name");
            return View();
        }

        // POST: Bookings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ResourceId,StartTime,EndTime,BookedBy,Purpose")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                // Check for booking conflict
                bool conflict = _context.Bookings.Any(b => b.ResourceId == booking.ResourceId &&
                    ((booking.StartTime < b.EndTime) && (booking.EndTime > b.StartTime)));

                if (conflict)
                {
                    ModelState.AddModelError("", "This resource is already booked during the requested time.");
                    ViewData["ResourceId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                        _context.Resources.Where(r => r.IsAvailable), "Id", "Name", booking.ResourceId);
                    return View(booking);
                }

                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ResourceId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                _context.Resources.Where(r => r.IsAvailable), "Id", "Name", booking.ResourceId);
            return View(booking);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
                return NotFound();

            ViewData["ResourceId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                _context.Resources.Where(r => r.IsAvailable), "Id", "Name", booking.ResourceId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ResourceId,StartTime,EndTime,BookedBy,Purpose")] Booking booking)
        {
            if (id != booking.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                // Check for conflicts, excluding the current booking
                bool conflict = _context.Bookings.Any(b => b.Id != booking.Id && b.ResourceId == booking.ResourceId &&
                    ((booking.StartTime < b.EndTime) && (booking.EndTime > b.StartTime)));

                if (conflict)
                {
                    ModelState.AddModelError("", "This resource is already booked during the requested time.");
                    ViewData["ResourceId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                        _context.Resources.Where(r => r.IsAvailable), "Id", "Name", booking.ResourceId);
                    return View(booking);
                }

                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Bookings.Any(e => e.Id == booking.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["ResourceId"] = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
                _context.Resources.Where(r => r.IsAvailable), "Id", "Name", booking.ResourceId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var booking = await _context.Bookings
                .Include(b => b.Resource)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (booking == null)
                return NotFound();

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
