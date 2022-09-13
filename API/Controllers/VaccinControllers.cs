using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Persistence;

namespace API.Controllers
{
    public class VaccinControllers : BaseApiController
    {
        private readonly DataContext _context;
        public VaccinControllers(DataContext context)
        {
            _context = context;
        }

        // [HttpGet]

        // public async Task<ActionResult<List<
    }
}