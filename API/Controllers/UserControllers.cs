using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class UserControllers : BaseApiController
    {
        private readonly DataContext _context;
        public UserControllers(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<User>> GetUsers(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}