using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DW3.Data;
using TrabalhoDW.TrabalhoDW.Models;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace DW3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            return _context.Events != null ?
                        View(await _context.Events.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Events'  is null.");
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var events = await _context.Events
                .FirstOrDefaultAsync(m => m.Id == id);
            if (events == null)
            {
                return NotFound();
            }

            return View(events);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,host_id,created_at,title,Description,start_time,end_time,location,is_private")] Events events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var events = await _context.Events.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            return View(events);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,host_id,created_at,title,Description,start_time,end_time,location,is_private")] Events events)
        {
            if (id != events.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!(await EventsExists(events.Id)))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }

        public async Task<bool> EventsExists(int id)
        {
            var eventById = await _context.Events.FindAsync(id);
            if (eventById == null)
            {
                return false;
            }

            return true;
        }


        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            try
            {
                var eventToDelete = await _context.Events.FindAsync(id);

                if (eventToDelete == null)
                {
                    return NotFound(); // Return a 404 Not Found response if the event is not found
                }

                _context.Events.Remove(eventToDelete);
                await _context.SaveChangesAsync();

                return NoContent(); // Return a 204 No Content response to indicate successful deletion
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Return a 500 Internal Server Error response if an exception occurs
            }
        }


        [HttpGet]
        [Route("createEvent")]
        public async Task<IActionResult> CreateEvent(int id, string title, string eventDate, string eventLocation, string eventEndDate, string eventDescription, string eventImageURL, bool eventIsPrivate, int maxPart)
        {

            DateTime startTime = DateTime.Parse(eventDate);
            DateTime endTime = DateTime.Parse(eventEndDate);

            // Check if the required parameters are provided
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(eventDate) || string.IsNullOrEmpty(eventLocation) || string.IsNullOrEmpty(eventEndDate) || string.IsNullOrEmpty(eventDescription) || string.IsNullOrEmpty(eventImageURL))
            {
                return BadRequest("All information is required.");
            }

            // Create a new event object
            var event1 = new Events
            {
                host_id = id,
                title = title,
                start_time = startTime,
                location = eventLocation,
                end_time = endTime,
                Description = eventDescription,
                Image = eventImageURL,
                is_private = eventIsPrivate,
                maxParticipants = maxPart,
            };

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TrabalhoDWBD;Trusted_Connection=True;MultipleActiveResultSets=true").Options;

                // Save the event to the database
                using (var context = new ApplicationDbContext(options))
                {
                    // Add the event to the context
                    context.Events.Add(event1);

                    // Save changes to the database
                    await context.SaveChangesAsync();
                }

                // Event created successfully
                return Ok(new { success = true });
            }
            catch (DbUpdateException)
            {
                // Error occurred while saving the event to the database
                return StatusCode(500, "An error occurred while creating the event.");
            }
        }

        [HttpGet]
        [Route("getEventIds")]
        public IActionResult GetEventIds()
        {
            var ids = _context.Events.Select(p => p.Id).ToArray();

            return Ok(ids); // Return the event ids as JSON response
        }



        [HttpPost]
        [Route("addParticipant")]
        public async Task<IActionResult> AddParticipant(int userId, int eventId)
        {
            try
            {
                var eventData = await _context.Events.FindAsync(eventId);

                if (eventData == null)
                {
                    return NotFound(); // Return a 404 Not Found response if the event is not found
                }

                var participant = new Participants
                {
                    UserFK = userId,
                    EventFK = eventId
                };

                _context.Participants.Add(participant);
                await _context.SaveChangesAsync();

                return Ok(); // Return a 200 OK response to indicate successful addition of the participant
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); // Return a 500 Internal Server Error response if an exception occurs
            }
        }


        [HttpGet]
        [Route("getEvent")]
        public ActionResult GetEventById(int id)
        {
            var eventData = _context.Events.FirstOrDefault(e => e.Id == id);

            if (eventData == null)
            {
                return NotFound(); // Return a 404 Not Found response if the event is not found
            }

            var participants = _context.Participants
                .Where(p => p.EventFK == id)
                .Select(p => p.UserFK)
                .ToArray();

            var result = new
            {
                EventData = eventData,
                Participants = participants
            };

            return Json(new { result }); // Return the event data as JSON, including the list of participants
        }



    }
}
