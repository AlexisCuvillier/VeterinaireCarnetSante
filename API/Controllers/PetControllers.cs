using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace API.Controllers
{
    public class PetControllers : BaseApiController
    {
        private readonly DataContext _context;
        public PetControllers(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<List<Pet>>> GetPets()
        {
            return await _context.Pets.ToListAsync();
        }

        [HttpGet("{id}")] 

        public async Task<ActionResult<Pet>> GetPets(Guid id)
        {
            return await _context.Pets.FindAsync(id);
        }

    }
}