using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using rui_ting_Project.Data;
using rui_ting_Project.Models;

namespace rui_ting_Project.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public BookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Bookings/Getall
        [Authorize(Roles = UserRoles.Admin)]
        [HttpGet("Getall")]
        public IActionResult GetAll()
        {
            return Ok(_context.Bookings.ToList());
        }

        // GET: api/Bookings/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var booking = _context.Bookings.FirstOrDefault(e => e.Booking_ID == id);
            if (booking == null)
                return NotFound("Booking with id " + id + " is not found.");

            return Ok(booking);
        }

        // POST: api/Bookings
        [HttpPost]
        public IActionResult Post([FromBody] Booking booking)
        {
            if (booking == null)
            {
                return BadRequest("Booking data is required.");
            }

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = booking.Booking_ID }, booking);
        }

        // PUT: api/Bookings/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Booking booking)
        {
            if (booking == null)
            {
                return BadRequest("Booking data is required.");
            }

            var entity = _context.Bookings.FirstOrDefault(e => e.Booking_ID == id);
            if (entity == null)
                return NotFound("Booking with id " + id + " is not found.");

            entity.Facility_Description = booking.Facility_Description;
            entity.Booking_Date_From = booking.Booking_Date_From;
            entity.Booking_Date_To = booking.Booking_Date_To;
            entity.Booked_By = booking.Booked_By;
            entity.Booking_Status = booking.Booking_Status;

            _context.SaveChanges();

            return Ok(entity);
        }

        // DELETE: api/Bookings/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var entity = _context.Bookings.FirstOrDefault(e => e.Booking_ID == id);
            if (entity == null)
                return NotFound("Booking with id " + id + " is not found.");

            _context.Bookings.Remove(entity);
            _context.SaveChanges();

            return Ok(entity);
        }
    }
}
