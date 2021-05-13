using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Persistence;
using Reactivities.Application.Core;

namespace Application.Activities
{
    public class List
    {
        public class Query : IRequest<Result<List<Activity>>> { }

        public class Handler : IRequestHandler<Query, Result<List<Activity>>>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public DataContext Context { get; }

            public async Task<Result<List<Activity>>> Handle(Query request, CancellationToken cancellationToken)
            {

                return Result<List<Activity>>.Success(await _context.Activities.ToListAsync(cancellationToken)); 
            }
        }
    }
}