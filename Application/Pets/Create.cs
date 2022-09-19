
using Domain;
using MediatR;
using Persistence;

namespace Application.Pets
{
    public class Create
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
                await  _context.Pets.AddAsync(request.Pet);

                 await _context.SaveChangesAsync();

                 return Unit.Value;
            }
        }
    }
}