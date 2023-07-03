using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DW3.Data;
using TrabalhoDW.TrabalhoDW.Models;

namespace DW3.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("createUser")]
        public async Task<IActionResult> CreateUser(string name, string email, string password)
        {
            // Perform user creation logic here
            // You can access the name, email, and password parameters to create a new user

            // Check if the required parameters are provided
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Name, email, and password are required.");
            }

            // Create a new user object
            var user = new Users
            {
                Name = name,
                Email = email,
                Password = password,
                img = "default.jpg"
            };

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TrabalhoDWBD;Trusted_Connection=True;MultipleActiveResultSets=true").Options;

                // Save the user to the database
                using (var context = new ApplicationDbContext(options))
                {
                    // Add the user to the context
                    context.Users.Add(user);

                    // Save changes to the database
                    await context.SaveChangesAsync();
                }

                // User created successfully
                return Ok(new { success = true });
            }
            catch (DbUpdateException)
            {
                // Error occurred while saving the user to the database
                return StatusCode(500, "An error occurred while creating the user.");
            }
        }

        [HttpGet]
        [Route("changeName")]
        public async Task<IActionResult> ChangeUserName(int id, string newName)
        {
            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TrabalhoDWBD;Trusted_Connection=True;MultipleActiveResultSets=true").Options;

                using (var context = new ApplicationDbContext(options))
                {
                    // Find the user with the provided ID
                    var user = await context.Users.FindAsync(id);

                    if (user != null)
                    {
                        // Update the username
                        user.Name = newName;

                        // Save changes to the database
                        await context.SaveChangesAsync();

                        // Return a success response
                        return Ok(new { success = true });
                    }

                    // User not found
                    return NotFound();
                }
            }
            catch (Exception)
            {
                // Error occurred while accessing the database
                return StatusCode(500, "An error occurred while accessing the database.");
            }
        }

        [HttpGet]
        [Route("changePassword")]
        public async Task<IActionResult> ChangePassword(int id, string previousPassword, string newPassword)
        {
            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TrabalhoDWBD;Trusted_Connection=True;MultipleActiveResultSets=true").Options;

                using (var context = new ApplicationDbContext(options))
                {
                    // Find the user with the provided ID
                    var user = await context.Users.FindAsync(id);

                    if (user != null)
                    {
                            // Update the username
                            user.Password = newPassword;

                            // Save changes to the database
                            await context.SaveChangesAsync();

                            // Return a success response
                            return Ok(new { success = true });
                    }

                    // User not found
                    return NotFound();
                }
            }
            catch (Exception)
            {
                // Error occurred while accessing the database
                return StatusCode(500, "An error occurred while accessing the database.");
            }
        }

        [HttpGet]
        [Route("checkPassword")]
        public IActionResult CheckPassword(int id, string password)
        {
            // Check if the required parameters are provided
            if (string.IsNullOrEmpty(password))
            {
                return BadRequest("Password is required.");
            }

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TrabalhoDWBD;Trusted_Connection=True;MultipleActiveResultSets=true")
                    .Options;

                using (var context = new ApplicationDbContext(options))
                {
                    // Find the user with the provided id
                    var user = context.Users.FirstOrDefault(u => u.Id == id);

                    if (user == null)
                    {
                        return NotFound("User not found.");
                    }

                    // Check if the provided password matches the user's password
                    bool isPasswordCorrect = user.Password == password;

                    // Return the result
                    return Ok(new { PasswordCorrect = isPasswordCorrect });
                }
            }
            catch (Exception)
            {
                // Error occurred while accessing the database
                return StatusCode(500, "An error occurred while accessing the database.");
            }
        }



        [HttpGet]
        [Route("CheckLogIn")]
        public IActionResult LogIn(string email, string password)
        {
            // Check if the required parameters are provided
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Email and password are required.");
            }

            try
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TrabalhoDWBD;Trusted_Connection=True;MultipleActiveResultSets=true").Options;

                using (var context = new ApplicationDbContext(options))
                {
                    // Find the user with the provided email and password
                    var user = context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);

                    if (user != null)
                    {
                        // Generate a session identifier or authentication token
                        string sessionId = Guid.NewGuid().ToString();

                        // Store the session identifier in a session store (e.g., ASP.NET Session State, cookies, or tokens)
                        // Example: HttpContext.Session.SetString("SessionId", sessionId);

                        // Return the user information along with the session identifier
                        return Ok(new
                        {
                            LoggedIn = true,
                            SessionId = sessionId,
                            User = user
                        });
                    }

                    // Return the result
                    return Ok(new { LoggedIn = false });
                }
            }
            catch (Exception)
            {
                // Error occurred while accessing the database
                return StatusCode(500, "An error occurred while accessing the database.");
            }
        }

        [HttpGet]
        [Route("getEvents")]
        public ActionResult GetEvents(int id)
        {
            var UserData = _context.Users.FirstOrDefault(e => e.Id == id);

            if (UserData == null)
            {
                return NotFound(); // Return a 404 Not Found response if the event is not found
            }

            var Events = _context.Events
                .Where(p => p.host_id == id)
                .Select(p => p.Id)
                .ToArray();

            return Json(new { Events }); // Return the event data as JSON, including the list of participants
        }

    }
}
