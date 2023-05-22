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
        [Route("getName")]
        public String getUserName(int id)
        {
            return _context.Users?.FirstOrDefault(u => u.Id == id).Name;
        }

        [HttpGet]
        [Route("getUsers")]
        public List<Users> getUsers()
        {
            var allUsers = _context.Users?.ToList();

            return allUsers;
        }
    }
}
