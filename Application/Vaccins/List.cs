using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Vaccins
{
    public class List
    {
        public class Query : IRequest<List<Vaccin>>
        {
        }

        
            public class Handler : IRequestHandler<Query, List<Vaccin>>
            {
            private readonly DataContext _context;
                public Handler(DataContext context)
                {
                _context = context;
                }

                public async Task<List<Vaccin>> Handle(Query request, CancellationToken cancellationToken)
                {
                   return await _context.Vaccins.ToListAsync();
                }
            }
    }
}