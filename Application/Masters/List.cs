using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Masters
{
    public class List
    {
        public class Query : IRequest<List<Master>>
        {
        }

        public class Handler : IRequestHandler<Query, List<Master>>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
            _context = context;
            }

            public async Task<List<Master>> Handle(Query request, CancellationToken cancellationToken)
            {
               return await _context.Masters.ToListAsync();
            }
        }
    }
}