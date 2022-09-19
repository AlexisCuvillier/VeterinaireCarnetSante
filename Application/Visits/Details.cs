using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Visits
{
    public class Details
    {
        public class Query : IRequest<Vaccin>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Vaccin>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;
            }

            public async Task<Vaccin> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Vaccins.FindAsync(request.Id);
            }
        }
    }
}