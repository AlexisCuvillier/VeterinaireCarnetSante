using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Vaccins;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class VaccinController : BaseApiController
    {
       [HttpGet]

       public async Task<ActionResult<List<Vaccin>>> GetVaccins()
       {
        return await Mediator.Send(new List.Query());
       }
    }
}