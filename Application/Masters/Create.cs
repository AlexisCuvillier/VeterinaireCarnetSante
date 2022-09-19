using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Masters
{
    public class Create
    {
         public class Command : IRequest
     {
        public Master Master { get; set; }
        
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
                await  _context.Masters.AddAsync(request.Master);

                 await _context.SaveChangesAsync();

                 return Unit.Value;
            }
        }
    }
}