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
        [Route("getUser")]
        public ActionResult<Users> GetUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                return NotFound(); // Retorna um 404 Not Found caso o usuário não seja encontrado
            }

            return user; // Retorna o objeto Users como resposta JSON
        }

        [HttpGet]
        [Route("getImgUser")]
        public String getUserImg(int id)
        {
            return _context.Users?.FirstOrDefault(u => u.Id == id).img;
        }



        [HttpGet]
        [Route("getUsers")]
        public List<Users> getUsers()
        {
            var allUsers = _context.Users?.ToList();

            return allUsers;
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
                Password = password
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
                return Ok(true);
            }
            catch (DbUpdateException)
            {
                // Error occurred while saving the user to the database
                return StatusCode(500, "An error occurred while creating the user.");
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
                    // Check if a user with the provided email and password exists
                    bool userExists = context.Users.Any(u => u.Email == email && u.Password == password);

                    if (userExists)
                    {
                        // Generate a session identifier or authentication token
                        string sessionId = Guid.NewGuid().ToString();

                        // Store the session identifier in a session store (e.g., ASP.NET Session State, cookies, or tokens)
                        // Example: HttpContext.Session.SetString("SessionId", sessionId);

                        // Return the result along with the session identifier
                        return Ok(new { LoggedIn = true, SessionId = sessionId });
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


    }
}
