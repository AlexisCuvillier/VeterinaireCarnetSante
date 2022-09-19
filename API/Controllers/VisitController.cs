using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Visits;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class VisitController : BaseApiController
    {
        [HttpGet]

        public async Task<ActionResult<List<Visit>>> GetVisit()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Visit>> GetVisitId(Guid id)
        {
            return Ok(await Mediator.Send(new Details.Query{Id = id}));
        }
    }
}