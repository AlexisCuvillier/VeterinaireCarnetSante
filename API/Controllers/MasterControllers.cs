using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Masters;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
    public class MasterControllers : BaseApiController
    {
         [HttpGet]

        public async Task<ActionResult<List<Master>>> GetMasters()
        {
            return await Mediator.Send(new List.Query());
        }

      
        [HttpGet("{id}")] 

        public async Task<ActionResult<Master>> GetMastersId(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreateMaster(Master master)
        {
            return Ok(await Mediator.Send(new Create.Command { Master = master}));
        }

        [HttpPut("{id}")]
        
            public async Task<IActionResult> EditMaster(Guid id, Master master)
            {
                master.Id = id;
                return Ok(await Mediator.Send(new Edit.Command{Master = master}));
            }
        

    }
}