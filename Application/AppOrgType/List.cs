using Application.Core;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.AppOrgType
{
    public class List
    {
        public class Query : IRequest<Result<List<OrgType>>> { }

        public class Handler : IRequestHandler<Query, Result<List<OrgType>>>
        {
            private readonly AppDbContext _context;
            public Handler(AppDbContext context)
            {
                _context = context;
            }

            public async Task<Result<List<OrgType>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return Result<List<OrgType>>.Success(await _context.OrgType.ToListAsync(cancellationToken));
            }
        }
    }
}