using Application.Pets;
using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    public class PetControllers : BaseApiController
    {
       

        [HttpGet]

        public async Task<ActionResult<List<Pet>>> GetPets()
        {
            return await Mediator.Send(new List.Query());
        }

      
        [HttpGet("{id}")] 

        public async Task<ActionResult<Pet>> GetPetsID(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost]
        public async Task<IActionResult> CreatePet(Pet pet)
        {
            return Ok(await Mediator.Send(new Create.Command { Pet = pet}));
        }

        [HttpPut("{id}")]
        
        public async Task<IActionResult> EditPet(Guid id, Pet pet)
        {
            pet.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Pet = pet}));
        }


    }
}