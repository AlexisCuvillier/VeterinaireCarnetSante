using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Visits
{
    public class List
    {
        public class Query : IRequest<List<Visit>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Visit>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;
            }

            public async Task<List<Visit>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Visits.ToListAsync();
            }
        }
    }
}