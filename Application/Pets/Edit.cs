using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Pets
{
    public class Edit
    {
        public class Command : IRequest 
        {
            public Pet Pet { get; set; }
            
        }
        public class Handler : IRequestHandler<Command>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
                 _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var pet = await _context.Pets.FindAsync(request.Pet.Id);

                pet.Name = request.Pet.Name ?? pet.Name;
                pet.Age = request.Pet.Age;

                await _context.SaveChangesAsync();

                return Unit.Value;
            }
        }
    }
}