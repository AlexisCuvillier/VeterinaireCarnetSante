using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Masters
{
    public class Details
    {
        public class Query : IRequest<Master>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Master>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;
            }

            public async Task<Master> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Masters.FindAsync(request.Id);
            }
        }

    }
}